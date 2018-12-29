Feature: PuppeteerSharpRepo

Scenario: Searching for the repo on GitHub
	Given I go to the GitHub start page
	When I search for "Puppeteer Sharp"
	Then the repo should be the first search result

Scenario: Master branch build status
	Given I go to the Puppeteer Sharp repo on GitHub
	When I check the build status on the master branch
	Then the build status should be success

Scenario: Latest release version
	Given I go to the Puppeteer Sharp repo on GitHub
	And I check the latest release version
	And I go to the Puppeteer repo on GitHub
	And I check the latest release version
	Then the latest release version should be up to date with Puppeteer
