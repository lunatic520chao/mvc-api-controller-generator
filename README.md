# mvc-api-controller-generator
mvc/api controller code generator when your project embeded the module connecting to mysql(or the other sqlserver).用于项目已经嵌入了连接数据库代码时根据model生成controller等代码<br />

# 用法:<br />
在bash中,进入这个项目路径中:<br />
将目标controller要用到model(xxxModel.cs)放入Models目录下,后运行cmd:<br />
dotnet aspnet-codegenerator controller -name xxxController -m xxxModel -dc xxxContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries<br />
将生成的controller(Controllers/xxxController.cs)、view(Views/xxx/*)、context(Data/xxxContext.cs)复制到你的项目中的对应路径即可.<br />
