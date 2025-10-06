-- 1. CREATE DATABASE
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'MiniProject2')
    CREATE DATABASE MiniProject2;
GO
USE MiniProject2;
GO

-- 2. CREATE DATABASE
CREATE TABLE Menu (
	Id				INT				IDENTITY(1,1)	NOT NULL,
	Name			NVARCHAR(100)	NOT NULL,
	Description		NVARCHAR(500)	NULL,
	CONSTRAINT PK_Menu PRIMARY KEY (Id)
);
GO

CREATE TABLE News (
	Id				INT				IDENTITY(1,1)	NOT NULL,
	MenuId			INT				NOT NULL,
	Title			NVARCHAR(100)	NOT NULL,
	Content			NVARCHAR(500)	NULL,
	CONSTRAINT PK_News PRIMARY KEY (Id)
);
GO

-- 3. RELATIONSHIP
ALTER TABLE News
ADD CONSTRAINT FK_Menu_News FOREIGN KEY (MenuId) REFERENCES Menu(Id);
GO

-- 4. INSERT DÂT
INSERT INTO Menu (Name, Description)
VALUES 
(N'Tin tức công nghệ', N'Cập nhật xu hướng và tin tức mới nhất về công nghệ.'),
(N'Sức khỏe & Đời sống', N'Chia sẻ kiến thức về sức khỏe, dinh dưỡng và lối sống lành mạnh.'),
(N'Giáo dục', N'Tin tức và bài viết về giáo dục, học tập và kỹ năng mềm.'),
(N'Giải trí', N'Bài viết về phim ảnh, âm nhạc, nghệ thuật và văn hoá.'),
(N'Thể thao', N'Cập nhật tin tức thể thao trong nước và quốc tế.');
GO

INSERT INTO News (MenuId, Title, Content)
VALUES
(1, N'Ra mắt iPhone 16 với chip A18 Bionic', N'Apple vừa chính thức công bố iPhone 16 với hiệu năng vượt trội và khả năng xử lý AI trên thiết bị.'),
(1, N'Xu hướng AI năm 2025', N'Trí tuệ nhân tạo tiếp tục là xu hướng dẫn đầu trong lĩnh vực công nghệ thông tin.'),
(1, N'Windows 12 sắp ra mắt', N'Microsoft tiết lộ kế hoạch phát hành Windows 12 với nhiều cải tiến đáng chú ý.'),
(2, N'5 thói quen giúp bạn ngủ ngon hơn', N'Các chuyên gia khuyến nghị duy trì lịch ngủ cố định và hạn chế dùng thiết bị điện tử trước khi ngủ.'),
(2, N'Bí quyết ăn uống lành mạnh', N'Tăng cường rau xanh, uống đủ nước và tránh thức ăn nhanh giúp cải thiện sức khỏe.'),
(3, N'Đổi mới giáo dục đại học tại Việt Nam', N'Bộ Giáo dục và Đào tạo đang triển khai đề án chuyển đổi số toàn diện trong giáo dục.'),
(3, N'Kỹ năng mềm quan trọng trong công việc', N'Giao tiếp, tư duy phản biện và làm việc nhóm là những kỹ năng cần thiết cho sinh viên.'),
(4, N'Phim bom tấn Marvel sắp khởi chiếu', N'Marvel Studio công bố phần tiếp theo của dòng phim Avengers với dàn diễn viên nổi tiếng.'),
(4, N'Ca sĩ Sơn Tùng M-TP ra mắt ca khúc mới', N'Bài hát mới được đầu tư kỹ lưỡng cả về giai điệu lẫn hình ảnh.'),
(5, N'Đội tuyển Việt Nam thắng đậm 3-0', N'Tuyển Việt Nam có chiến thắng thuyết phục trước đối thủ mạnh tại vòng loại World Cup.'),
(5, N'Ronaldo lập hat-trick ở tuổi 40', N'Ngôi sao Bồ Đào Nha chứng minh phong độ đỉnh cao dù đã ngoài tứ tuần.');
GO