/*----------------------------------------------------------
CAC THANH VIEN NHOM:
    47.01.104.095 - Lê Kim Hưng
    47.01.104.050 - Trương Đinh Thiên Bảo
    47.01.104.233 - Nguyễn Cát Tường
    47.01.104.182 - Trần Thanh Sang
LAB: 03 - NHOM
NGAY: 07-04-2024
----------------------------------------------------------*/
-- CAU LENH TAO DB
USE MASTER

DROP DATABASE IF EXISTS QLSVNhom
CREATE DATABASE QLSVNhom
GO

USE QLSVNhom

-- CAC CAU LENH TAO TABLE
CREATE TABLE NHANVIEN (
    MANV        VARCHAR(20)     PRIMARY KEY,
    HOTEN       NVARCHAR(100)   NOT NULL,
    EMAIL       VARCHAR(20),
    LUONG       VARBINARY(MAX),
    TENDN       NVARCHAR(100)   NOT NULL,
    MATKHAU     VARBINARY(MAX)  NOT NULL,
    PUBKEY      VARCHAR(20), --Ten khoa cong khai
)

CREATE TABLE HOCPHAN (
    MAHP        VARCHAR(20)     PRIMARY KEY,
    TENHP       NVARCHAR(100)   NOT NULL,
    SOTC        INT,
)

CREATE TABLE LOP (
    MALOP       VARCHAR(20)     PRIMARY KEY,
    TENLOP      NVARCHAR(100)   NOT NULL,
    MANV        VARCHAR(20),
    
    FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
)

CREATE TABLE SINHVIEN (
    MASV        VARCHAR(20)     PRIMARY KEY,
    HOTEN       NVARCHAR(100)   NOT NULL,
    NGAYSINH    DATETIME,
    DIACHI      NVARCHAR(200),
    MALOP       VARCHAR(20),
    TENDN       NVARCHAR(100)   NOT NULL,
    MATKHAU     VARBINARY(MAX)  NOT NULL,

    FOREIGN KEY (MALOP) REFERENCES LOP(MALOP),
)

CREATE TABLE BANGDIEM (
    MABANGDIEM  VARCHAR(20)     PRIMARY KEY,
    MASV        VARCHAR(20),
    MAHP        VARCHAR(20),
    DIEMTHI     VARBINARY(MAX), --Ma Hoa
    
    FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV),
    FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV),
)
GO

-- CAU LENH TAO STORED PROCEDURE
-- i) ------------------------------------------------
CREATE OR ALTER PROCEDURE SP_INS_PUBLIC_NHANVIEN (
    @MANV       VARCHAR(20),
    @HOTEN      NVARCHAR(100),
    @EMAIL      VARCHAR(20),
    @LUONGCB    VARCHAR(20),    --(truoc khi ma hoa)
    @TENDN      NVARCHAR(100),
    @MK         VARCHAR(20)     --(gia tri truoc khi ma hoa)
) AS BEGIN
    DECLARE @PassEncryption     VARBINARY(MAX)
    DECLARE @SalaryEncryption   VARBINARY(MAX)

    -- Encrypt password
    SET @PassEncryption = HASHBYTES('SHA1', @MK)

    -- Encrypt salary
    IF (AsymKey_ID(@MANV) IS NULL) BEGIN
        DECLARE @CreateASymKey NVARCHAR(MAX)
        SET @CreateASymKey = 'CREATE ASYMMETRIC KEY ' + QuoteName(@MANV) + ' WITH ALGORITHM = RSA_2048 ENCRYPTION BY PASSWORD = ''' + @MK + ''''
        EXECUTE sp_executesql @CreateASymKey
    END
    SET @SalaryEncryption = EncryptByASymKey(AsymKey_ID(@MANV), @LUONGCB)

    -- Insert data
    INSERT INTO NHANVIEN 
            (MANV,  HOTEN,  EMAIL,  LUONG,              TENDN,  MATKHAU,         PUBKEY)
    VALUES  (@MANV, @HOTEN, @EMAIL, @SalaryEncryption,  @TENDN, @PassEncryption, @MANV)
END
GO

EXECUTE SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN VAN A', 'NVA@yahoo.com', 3000000, 'NVA', 'abcd12'
EXECUTE SP_INS_PUBLIC_NHANVIEN 'NV02', 'NGUYEN VAN B', 'NVB@yahoo.com', 2000000, 'NVB', '1234567'
GO

-- ii) -----------------------------------------------
CREATE OR ALTER PROCEDURE SP_SEL_PUBLIC_NHANVIEN  (
    @TENDN      NVARCHAR(100),
    @MK         VARCHAR(20)
) AS BEGIN
    DECLARE @PassEncryption VARBINARY(MAX)
    SET @PassEncryption = HASHBYTES('SHA1', @MK)

    SELECT MANV
         , HOTEN
         , EMAIL
         , CONVERT(VARCHAR, DecryptByASymKey(AsymKey_ID(MANV), LUONG, Cast(@MK AS NVARCHAR(20)))) AS LUONGCB
    FROM
        NHANVIEN
    WHERE NHANVIEN.TENDN   = @TENDN
      AND NHANVIEN.MATKHAU = @PassEncryption
END
GO

EXEC SP_SEL_PUBLIC_NHANVIEN 'NVA', 'abcd12'
GO
---------------------------------------------------------------------
CREATE OR ALTER TRIGGER SP_UPDATE_POINTS ON BANGDIEM
FOR UPDATE AS
BEGIN
    DECLARE @MANV VARCHAR(20)
    DECLARE @PublicKey VARBINARY(MAX)

    -- Lấy MANV từ bảng NHANVIEN với dữ liệu được cập nhật
    SELECT @MANV = MANV FROM NHANVIEN WHERE MANV IN (SELECT MANV FROM inserted)

    -- Lấy public key tương ứng với MANV
    SELECT @PublicKey = CAST(PUBKEY AS VARBINARY(MAX)) FROM NHANVIEN WHERE MANV = @MANV

    -- Kiểm tra xem khóa đã tồn tại trong cơ sở dữ liệu chưa, nếu không thì tạo mới
    IF (AsymKey_ID(@MANV) IS NULL) BEGIN
        DECLARE @CreateASymKey NVARCHAR(MAX)
        SET @CreateASymKey = 'CREATE ASYMMETRIC KEY ' + QuoteName(@MANV) + ' WITH ALGORITHM = RSA_2048 ENCRYPTION BY PASSWORD = '''''
        EXEC sp_executesql @CreateASymKey
    END

    -- Mã hóa điểm thi bằng RSA với public key
    UPDATE BANGDIEM
    SET DIEMTHI = EncryptByASymKey(AsymKey_ID(@MANV), i.DIEMTHI)
    FROM BANGDIEM
    JOIN inserted i ON BANGDIEM.MASV = i.MASV
END
GO

CREATE OR ALTER PROC SP_LOGIN
    @TENDN NVARCHAR(100),
    @MATKHAU VARCHAR(100),
    @KETQUA INT OUTPUT,
    @MANV VARCHAR(100) OUTPUT
AS
BEGIN
    DECLARE @PASSNHANVIEN VARBINARY(MAX)
    SET @PASSNHANVIEN = HASHBYTES('SHA1', CONVERT(VARBINARY(MAX), @MATKHAU))
    
    SELECT @MANV = MANV
    FROM NHANVIEN
    WHERE NHANVIEN.TENDN = @TENDN AND NHANVIEN.MATKHAU = @PASSNHANVIEN

    IF @@ROWCOUNT > 0
    BEGIN
        SET @KETQUA = 1
    END
    ELSE
    BEGIN
        SET @KETQUA = 0
    END
END
