START /WAIT %CD%\packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe "%CD%\Linnworks_Test_Automation\bin\Debug\Linnworks_Test_Automation.dll" --testlist="%CD%\TestsListToRun.txt"

echo Starting of the file on %date% at %time%
cd %~dp0
echo "Generating HTML Report"
("%~dp0\packages\ReportUnit.1.5.0-beta1\tools\ReportUnit.exe" "%~dp0\TestResult.xml" "%~dp0\TestResult.html")
echo "HTML Report generated successfully!!"