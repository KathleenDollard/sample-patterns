# Demo script

First, I forgot to run the tests, so let's make sure we are starting with a known good.

## Records

(One test fails)

Let's look at that test. OK, just a simple test for value equality, we better look at that class. 

Before we get figure that out, something is really bugging me. There's a double indent here, which I know we do not need, and the same thing was going on in the tests. Blech!

I'm just going to fix that for the whole solution.

Ok, now, you might think it has something to do with immutability

Jump back to slides to orthogonal heap/value eq/immutability (2 slides)

So, nope, not that. We could break this test down to see just what's failing, but it's that array, lists, etc have reference equality by default.

To fix this, I'm going to include a custom Equals and GetHashCode. 

I'm not going to implement my own hashing, I'm just going to combine hashes.

How many of you are supporting .NET Standard?

How many of you are using a version of C# greater than 7.3 in .NET Standard? How many of you do not know?

Records are nice for value equality. They should probably be used for all structs. 

## Global usings

By hook or by crook, but your global usings in

### In any file :sad:

Hard to find

### In a `GlobalUsings.cs` file

(Show one in TollCalcLib)

Easy to find, must be in every project

### In the project file

- Fix column replace, with `end` key
- Fix with Replace
- Show help in CtlShiftFind
  - Switch to RegEx and look for icon to the right of the search string

Do not be afraid of project files and do not fear the RegEx

### In a `directory.build.props` file

Many global usings apply to the whole repo, or solution. 

Use folder based `Directory.Build.props`. Don't get me started on that name. And the errors if you mistype the case are, well, not helpful

Great place for global usings, common packages, common C# settings, .NET versions, etc

But you can't include an invalid global using here, for example, can't use TollCalculatorLib here. 

Fix TollCalculator .csproj and global using

### More on using

How do you know what you're current global usings are?

Little glyph (slide on how to enable)

Wait, where did all those come from? 

You can remove them as well!

## Patterns

