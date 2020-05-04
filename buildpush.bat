set commit_message=%1
IF [%1] == [] (
    set commit_message="something new"
)

echo %commit_message%

dotnet ..\Fornax\src\Fornax\bin\Debug\netcoreapp3.1\Fornax.dll build
IF NOT %ERRORLEVEL == 0 (
    EXIT /B  42
)

git add .
git commit -m %commit_message%
git push origin master

xcopy _public ..\robertpi.github.io /S /Y /C

pushd ..\robertpi.github.io
git add .
git commit -m %commit_message%
git push origin master
popd