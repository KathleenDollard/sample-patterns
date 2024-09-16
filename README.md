## Sample code for C# patterns 

This entire solution is sample code and there is no claim about its value beyond learning about C# features.  

This is a variation of the toll calculator example you will find at https://docs.microsoft.com/dotnet/csharp/fundamentals/tutorials/pattern-matching. The code is a simple toll calculator that calculates the toll for a vehicle based on the type of vehicle and the time of day. You can learn more about the problem and the patterns used in that Microsoft Learn article. 

I reversed that code to pre-pattern matching C# code to allow you to experiment adding pattern matching to an existing code base - similar to what you might do with your own code. The non-pattern match code is in the `main` branch. There are branches for some of the presentations where I used this example that show a finished version of the code.

I recommend you work from the bottom up. The hardest method to fix is the first one. Experiment with auto-complete with Ctl-. and see what the IDE suggests. It will be different at different spots in the code and indicated by a slight grey underscore. 

Also, the docs with the variety of patterns is excellent: https://learn.microsoft.com/dotnet/csharp/language-reference/operators/patterns.

Enjoy! Patterns are fun and can make it much easier to casually understand the code of your application.