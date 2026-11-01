# Demo script

First, I forgot to run the tests, so let's make sure we are starting with a known good.

## Warnings and errors

You can set the severity for most warnings and errors, and you can run with TreatWarningsAsErrors


## Guardrails

Lets run the tests...

Well, most of them pass, let's ship it

Let's look at the ValueEquality test first.

Records do not have deep value equality, because getting it right in all cases without your undertanding didn't work out. You'll have to do this yourself, so I really like tests like these.

OK, all of the calculations are failing, returning integer.MinValue. Let's step through this

Well, that's a pretty simple error, but why didn't the compiler catch it?

If you say something can be anything, it can be anything. Use generics and interfaces wherever you can to avoid object.

But, you need object when the type you are working with can be anything, and the general concept of a vehicle can be anything and comes from other systems, so we can't use interfaces.

## Records 

I include  `class` so I do not have to remember that default

(One test fails)

Let's look at that test. OK, just a simple test for value equality, we better look at that class. (RideShare value equality)

Records are great for value equality, 
 - but they do not test for deep value equality. 
 - Specifically, no value equality for contained nested complex type by default
 - That includes lists, arrays, etc.

Add an Equals and a GetHashCode, always both. I'll just uncomment this.

Records are nice for value equality. Use them for all structs. 

## Patterns

`TollCalculator` only has one public method. It calls `CalculateToll` and `PeakTimePremium`, which call a few more methos. 

Easiest in this particular case to start at the bottom.

Change `TimeBand` and `IsWeekDay` to use patterns.

On `PeakTimePremium`, first demonstrate unassigned local variable catching an error by not setting the retValue variable.

Then use pattern matching.

`CalculateToll` is pretty nasty, and it's unlikely you'd ever share it with a stakeholder.

To keep things moving, I'm going to copy in the `switch` statement, then flip back and forth between them



## Unions