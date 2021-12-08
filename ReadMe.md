# 1目标:做一个mvc+sqlite的项目用于其他mvc/api项目生成需要访问sql的模型的controller
# 2过程
## 2-1编写model代码.
## 2-2运行cmd
```sh
dotnet add package --version 3.1 Microsoft.EntityFrameworkCore.Tools;
dotnet add package --version 3.1 Microsoft.EntityFrameworkCore.Design;
dotnet add package --version 3.1 Microsoft.EntityFrameworkCore.SQLite;
dotnet add package --version 3.1 Microsoft.VisualStudio.Web.CodeGeneration.Design;
dotnet add package --version 3.1 Microsoft.EntityFrameworkCore.SqlServer;
dotnet add package --version 3.1 Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
dotnet add package --version 3.1 Microsoft.AspNetCore.Identity.EntityFrameworkCore;
dotnet add package --version 3.1 Microsoft.AspNetCore.Identity.UI;
export PATH=$HOME/.dotnet/tools:$PATH;

dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

dotnet aspnet-codegenerator controller -name DepartController -m DepartMember -dc SqlContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```
## 2-3更新startup.cs和appsettings.json
更新startup.cs和appsettings.json,使得开发时使用sqlite,生产使用mssqlserver/mysqlserver,连接字符串使用对应的字符串.
startup.cs的构造添加个参数IWebHostEnvironment env;保存到属性Env中.

# 3完成度:已完成.


# 4用法:
在bash中,进入这个项目路径中:
将目标controller要用到model(xxx.cs)放入Models目录下,后运行cmd:
dotnet aspnet-codegenerator controller -name DepartController -m DepartMember -dc SqlContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
将生成的controller(Controllers/xxxController.cs)、view(Views/xxx/*)、context(Data/xxxContext.cs)复制到你的项目中的对应路径即可.

