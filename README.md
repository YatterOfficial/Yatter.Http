## Alpha Alert!

We are progressively building this solution from a custom ListView pattern that we already use in Xamarin Forms, and as you can't read our mind, you wont know from one week to another where we are going on this. So beware. We are, however, developing on various branches, and commiting approved updates to the master branch, so the master branch can be considered to have better form than the development branches. It's a winding road to Camelot!

# Yatter.Http.ResponsiveHttpClient

A lightweight implementation of ```System.Net.HttpClient``` optimised for mobile using a generics ```TRequest/TResponse``` pattern; uses ```C#``` and is Unit Tested using the Open Weather Map API as an information source.

This is based upon the author's own project (circa Feb 2017) at [https://github.com/HarrisonOfTheNorth/ResponsiveHttpClient](https://github.com/HarrisonOfTheNorth/ResponsiveHttpClient)

Until we update this ReadMe, the ReadMe in that repo is current for this one, which has extensive examples, including how that one was unit tested.

We intend releasing a Nuget package for this really soon.

### INTRODUCTION
This library is being created in support of our [Yatter API](https://github.com/HarrisonOfTheNorth/Yatter), which utilises both:

- [HarryHotdog.UI.Blazor.Components](https://github.com/HarrisonOfTheNorth/HarryHotdog.UI.Blazor.Components), and
- [HarryHotdog.UI.ListBuilder](https://github.com/HarrisonOfTheNorth/HarryHotdog.UI.ListBuilder)

and which demonstrates a lightweight ListView builder and Blazor renderer.

The list that is built by ListBuilder can be serialised into both JSON and XML, and deserialised back into the list, hence we wish to easily generate such lists in JSON and XML on the server and consume them in the .NET Maui Blazor app.

Given that the serialisation and deserialisation will be constant in accordance with the shape of the object that the ListBuilder generates, it is sensible for the app to make requests of the server in a defined TRequest/TResponse pattern.

Our ```ResponsiveHttpClient```, herein, is quite easily capable of such TRequest/TResponse pattern behaviour.

