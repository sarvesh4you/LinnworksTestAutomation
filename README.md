### Linnworks - Test Automation

**Page Object Factory implementation**

Summary:

This framework uses external page object implementation. This is good for frequently changing UI and Test First approach.

#### System Requirement:

* Microsoft Visual Studio or any other of choice in case there is need to update the script. (optional)
* For execution of scripts on Chrome, Internet explorer, Firefox and Edge, you need to have executable files drivers respectively 
*[Note] Please do use IE 32 bit version.
* You can download these executable files from below links
  * Chrome: [Download compatible chromedriver](https://sites.google.com/a/chromium.org/chromedriver/downloads)
  * IE: [Download compatible IEdriver](https://www.seleniumhq.org/download/)
  * Edge: [Download compatible MicrosoftWebDriver](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/)
  * Firefox: [Download compatible geckodriver](https://github.com/mozilla/geckodriver/releases)
 

#### Execution Steps:
Please follow the instructions to execute the tests on local:

1. According to the Test Scope use following commands
  - To Execute the Test Suite
	``` START /WAIT %~dp0packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe "%~dp0Linnworks_Test_Automation\bin\Debug\Linnworks_Test_Automation.dll" --testlist=""%~dp0TestListToRun.txt"" ```
	``` TestListToRun.txt file contain list of test suits to execute ```
  - To Execute the single Test Case	
    ``` START /WAIT %~dp0packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe "%~dp0Linnworks_Test_Automation\bin\Debug\Linnworks_Test_Automation.dll" --test="testcasename" ``` 
2. Or use already created batch files for execution purpose
  - To Execute the Test Suite : RunTestList.bat
  
####Automation Framework and Package Structure:
  -Spec File Based Framework
	
**Spec File Based FrameWork**
  It comprises three main folders:-
  1) test
  2) pages
  3) resources

1)test
  test contains 1 folder
  ``` elements ```
  
  1) elements
  elements folder contains 4 subfolders
  1)com.linnworks.automation
  2)com.linnworks.automation.getpageobjects
  3)com.linnworks.automation.tests
  4)com.linnworks.automation.utils

   
**com.linnworks.automation**
	It contains two classes
    1)DriverInitiators :- Comprises the configuration of browsers chrome, IE, Firefox, Safari, Edge
	2)TestSessionInitiator :- Comprises the methods to initialize a test session

**com.linnworks.automation.getpageobjects**
	1)BaseUI :- contains all generic methods like click, senkeys, scroll, select etc.
	2)GetPage :- Contains the generic implementations

	
**com.linnworks.automation.tests**
Test wrote for the Ui/Functional/API/Database automation need to be placed in this folder.
   
**com.linnworks.automation.utils**
	1)ConfigFileReader: Utility to read and write the config files
	2)SeleniumWait:- Utility to set the selenium Implicit and explicit waits.
	3)TakeScreenshot:- Utility to capture the failure screenshots.
	4)YamlReader:- Utility to read  the Yaml files.
   
	
2) pages
Contains Action classes for each test, the Action methods use elements declared in the spec file and those element are then fed to different actions defined in BaseUi present in the com.linnworks.automation.getpageobjects folder.
  
3) resources 
  It contains four folder
  1)configs
  2)drivers
  3)specs
  4)testdata  

**configs**
  File has the key value structure used to define the test configuration of system like selection of browser, timeout for the element visibility waits etc.

**drivers**
  Folder consist the executable files of browsers needed to launch the respective browser using selenium.
  
**specs** 
  Folder contains the location of the UI elements

**Testdata** 
  Folder has the images,properties and yaml files used for passed the Test Data.
   

#### Result Files:	
The Test Execution Results will be stored in the following directory once the test has completed

1) Xml file is generated by default when we execute test cases via NUnit:
    ./TestResult.xml (for complete test suite)
	
2) For generating HTML file, execute below command:
	``` echo Starting of the file on %date% at %time%
		cd %~dp0
		echo "Generating HTML Report"
		("%~dp0\packages\ReportUnit.1.5.0-beta1\tools\ReportUnit.exe" "%~dp0\TestResult.xml" "%~dp0\TestResult.html")

		echo "HTML Report generated successfully!!" ```
		
	Generated HTML File path is:
	./TestResult.html

    