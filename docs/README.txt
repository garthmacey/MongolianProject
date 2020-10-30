2-fnd5a
Food Ordering System
Team Members:
	
Nick Baerwald
	
Nic Skronoski
	
Noah Schroeder
	
Garth Macey



To build the system open the project solution in the file FoodOrderingSystem inside visual studio and click run this

will build the solution.

The files that are needed to run the project are all within the FoodOrderingSystem file. To run 
the test cases the test need to be run from the test tab in visual studio or with the shortcut ctrl+r,a

All files are placed as they
 need to be.



There are no assumptions about locations of documents on the network.



All known bugs along with explanations of why those bugs could not be fixed. "Not enough time" 
is certainly a valid reason! 
If there are no known bugs, say so, but note that if I find undocumented 
bugs during the demo you could lose further points!



The chef view needs to be instanciated before the orders will appear on the view. If this is not done first then 
The orders will not appear. This was not fixed as we ran out of time to fiqure out how to get the view to instanciate
with out having to visit it first.



Any known design deficiencies.



To generate test coverage results within visual studio the tests can be run from the test tab. And the test coverage 
results can be found by clicking Test -> Analys Code Coverage -> All Tests. This generates a report that shows all
code that is covered by the test in the UnitTest file. The files that are not covered are the Views and the ViewModels.
The classes in Model are all at 100% code coverage.






If (NuGetIssues)
	
   Update MSTest.TestAdapter and MSTest.TestFramework
	
      If (Still Broken)
		
         Uninstall MSTest.TestAdapter
		
         ReInstall MSTest.TestAdapter