# Demo script

## Let's look at this TollCalculator project

Different assemblies for different things

## Tests

Oh, I forgot to run the tests, so let's make sure we are starting with a known good.

Two tests fail. Let's do the value equality one first. 

## Understanding type variation

Tests in Modern C# project, TypeBehaviorTests

Records are particularly important for struct, to avoid reflection and allow AOT

## Back to the equality test

Uncomment the CompanyIds code, discussing that there is no deep equality

These kinds of tests are valuable to leave in your system.

## To the TollCalculator test failure

OK, all of the calculations are failing, returning integer.MinValue. Let's step through this

Well, that's a pretty simple error, but why didn't the compiler catch it?

If you say something can be anything, it can be anything. Use generics and interfaces wherever you can to avoid object.

But, you need object when the type you are working with can be anything, and the general concept of a vehicle can be anything and comes from other systems, so we can't use interfaces.

## Unions

Fix it with a Vehicle union in TollCalculatorLib. Fix the gantry reading.

There is now a compiler error in TollCalculator. Three cheers for guardrails!

## Closed types

Nothing technically the same, but there may be times you are choosing between unions and closed type hierarchies.

Demo, with sealed

If you have a type hierarchy already, or know you want one, prefer closed type hierarchies

If you don't control your types, use unions

## Warnings and errors

You can set the severity for most warnings and errors, and you can run with TreatWarningsAsErrors

## Patterns

`TollCalculator` only has one public method. It calls `CalculateToll` and `PeakTimePremium`, which call a few more methos. 

Easiest in this particular case to start at the bottom.

Change `TimeBand` and `IsWeekDay` to use patterns.

On `PeakTimePremium`, first demonstrate unassigned local variable catching an error by not setting the retValue variable.

Then use pattern matching.

`CalculateToll` is pretty nasty, and it's unlikely you'd ever share it with a stakeholder.

To keep things moving, I'm going to copy in the `switch` statement, then flip back and forth between them

_Expressions over statements_

## Unions

