# Goal

Excercise your overall coding skills by extending this application. This application represents in a large part a simplified version of our application stack. Proving that you can find your way around this code base, while navigating the amount of OSS code involved will help demonstrate your capabilties to our team.

# Getting Started

- run 'rake' -- from here on out it should build in visual studio

# Requirements:

- Extend the 'PickupOrder' to have 'First Name' and 'Last Name' properties inplace of one 'Name' property.
- Present the 'Pizza Type' in another fashion than a dropdown
- Capture an additional required field 'Phone Number' from the user.
  - Phone number should be implemented as a micro type
  - using a Html Convention present the phone number as a series of three boxes on edit
  - using a Html Convention (not ToString) present the phone number in the form '(xxx) xxx-xxxx'
- Add a route to display a list of current orders in the system
- Do something to impress us (code related please -- no videos of you juggling chainsaws or anything like that)
- You MUST support: IE8 and later, FireFox (latest), and Chrome (latest)
- When you send us your code:
  - We will run this command: `rake`
  - We expect the last few lines of the output to look something like this:
    
    ```
    Tests run: XX, Errors: 0, Failures: 0, Inconclusive: 0, Time: 0.6510372 seconds
      Not run: 0, Invalid: 0, Ignored: 0, Skipped: 0
    ```

# Optionals:

- You MAY enhance the UI how ever you like.

#Notes

- You may use whatever tools you like to develop and test -- but we will run 'rake' to compile and test your code
