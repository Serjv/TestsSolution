@pushd %~dp0


"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" "APITests.csproj"


@cd ..\packages\SpecRun.Runner.*\tools\net45

@set profile=%1
@if "%profile%" == "" set profile=Default

@if exist "%~dp0\bin\Debug\%profile%.srprofile" (
    SpecRun.exe run "%profile%.srprofile" --baseFolder "%~dp0\bin\Debug" --log "specrun.log" %2 %3 %4 %5
) else (
    SpecRun.exe run --baseFolder "%~dp0\bin\Debug" --log "specrun.log" %2 %3 %4 %5
)

:end

@popd
