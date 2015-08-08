# Project notes - CSD 2015.

I download markdown tools for VS2013 
[here](https://visualstudiogallery.msdn.microsoft.com/0855e23e-4c4c-4c82-8b39-24ab5c5a7f79 "Markdown tools")

## Activities:

- Create a new solution under VS2013.

- Create a Class Library C# project titled Module1

- Need to add the following references:
	
		NUnit
		Selenium Driver

- I update file _AssemblyInfo.cs_ file to include the lines below because WatiN requires a single threaded:

		using NUnit.Framework;
		[assembly:RequiresSTA]
		Use NuGet to install SpecFlow.NUnit

- I create a feature file: _AdoptMultiplePuppies.feature_:

		Feature: Adopting multiple puppies
		  In order to have the puppies chew my furniture
		  As a pet owner,
		  I want to adopt two puppies
		
		@Wip
		  Scenario: Adopting multiple puppies from the website.
		    Given that I am at the website "http://localhost:3000"
		    When I adopt for these pets, 
			  | petName    |
		      | Brook      |
		      | Hanna      |
		      | Maggie Mae |
		    And I pay for the adoption using this type of payment:
		      | paymentType | orderName   | orderAddress    | orderEmail         |
		      | Check       | Mr. Baloney | 123 Main Street | baloney@sleezy.com |
		    Then I should be back at the main page with a thank you note, "Thank you for adopting a puppy!" 

- I generate Step Definitions