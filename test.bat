@echo off
Packages\xunit.runner.console.2.0.0\tools\xunit.console ^
	SMCLoanFacts\bin\Debug\SMCLoanFacts.dll ^
	-parallel all ^
	-html Result.html ^
	-nologo -quiet
@echo on 