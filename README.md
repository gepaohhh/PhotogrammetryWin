# 摄影测量课程作业
## 开发环境
Visual Studio 2022
框架 .NET 8.0 
## 语言
C#
## 文件结构
主要有5个部分，由三个文件夹FileStream、Props、Utils和两个MainForm.cs、Program.cs。\
(1) FileStream文件夹中存储了读取txt文件方法，包含了ReadRelativeOrientation.cs读取相对定向文件和ReadResectionFile.cs读取后方交会文件。\
(2) Props文件夹中存储的是一些属性值，包含了Camera.cs存储相机的内外方位元素、  GCP.cs存储地面控制点和对应像点值和HomonymyPoint.cs存储左右相片中的同名点值。\
(3) Utils文件中存储的是一些基本的计算工具以及相对定向和后方交会的计算方法，包含了CalRelativeOrientation.cs计算相对定向、CalResction.cs计算后方交会、MatrixCal.cs矩阵计算和Tools.cs角度转换以及旋转矩阵R计算。
## 算法实现
1、空间后方交会\
2、相对定向
