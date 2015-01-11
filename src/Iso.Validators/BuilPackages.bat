if not exist "./NuGet Packages" mkdir "./NuGet Packages"
call "./../.nuget/NuGet.exe" pack Iso.Validators.csproj -Build -IncludeReferencedProjects -Properties Configuration=Release -OutputDirectory "./NuGet Packages"
