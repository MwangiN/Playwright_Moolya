using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

public class LoginTest
{
    static async Task Main(string[] args)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();

        // Create a new browser context
        var context = await browser.NewContextAsync();

        // Create a new page within the context
        var page = await context.NewPageAsync();

        // Navigate to the web application login page
        await page.GotoAsync("https://practicetestautomation.com/practice-test-login/");

        // Fill in the login form
        await page.FillAsync("#username", "student");
        await page.FillAsync("#password", "Password123");

        // Submit the form
        await page.ClickAsync("#submit");

        // Check if the logout button is present on the dashboard page
        var logoutButton = await page.QuerySelectorAsync("wp-block-button");

        if (logoutButton != null)
        {
            Console.WriteLine("Login and dashboard test passed!");
        }
        else
        {
            Console.WriteLine("Login and dashboard test failed!");
        }

        // Close the browser
        await browser.CloseAsync();
    }
}
