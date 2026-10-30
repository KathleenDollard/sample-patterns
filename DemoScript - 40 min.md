# Demo script

First, I forgot to run the tests, so let's make sure we are starting with a known good.

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

## Unions