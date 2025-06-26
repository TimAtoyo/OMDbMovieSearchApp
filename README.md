# OMDbMovieSearchApp
# Movie Search Web App

This is a web application built using Blazor (ASP.NET Core) for searching movies, series, and episodes using the free OMDb API (https://www.omdbapi.com/).

## Overview

The application provides a user-friendly interface to search for media by title and release year. Search results, including title, year, type and a poster image, are displayed in a clean, card-based layout using bootstrap for ui. 

## Technologies Used

* **C#:** The primary language for all application logic.
* **Blazor (ASP.NET Core Interactive Server):** Chosen for building the interactive web UI, using C# for both frontend and backend logic.
* **OMDb API:** Utilised as the data source for fetching movie, series, and episode information.
* **HttpClient:** Used within the `OMDbService` to make asynchronous HTTP requests to the OMDb API.
* **System.Text.Json:** The built-in .NET JSON serialiser/deserialiser, used for parsing the API responses into C# objects.
* **Bootstrap:** For basic styling, responsive layout (grid system for movie cards), and UI components (inputs, buttons, cards).

## Project Structure

* `Models/Movie.cs`: Defines the `Movie` class to represent individual movie data received from the OMDb API.
* `Models/SearchResponse.cs`: Defines the `SearchResponse` class to encapsulate the overall API response, including a list of `Movie` objects and potential error messages.
* `Services/IOMDbService.cs`: Interface for the `OMDbService`, promoting dependency inversion and testability.
* `Services/OMDbService.cs`: Implements `IOMDbService`, handling the actual API calls to OMDb and deserialising the JSON response. It uses a pre-defined API key.
* `Pages/SearchComponent.razor`: The main Blazor component, containing the user interface for input, search button, loading indicator, and displaying the search results.

## Features

* **Search by Title:** Users can enter a movie/series/episode title.
* **Search by Release Year:** Users can optionally specify a release year to refine search results.
* **Dynamic Search:** Search results are fetched asynchronously and displayed interactively.
* **Loading Indicator:** A "Loading..." message is shown while data is being fetched.
* **No Results Feedback:** Clearly indicates when no movies are found for the given search criteria.
* **Image Fallback:** If a poster image is not available from the API, a placeholder image is displayed instead (used chat gpt for this as i wasn't sure how to implement).


## Design and Code Considerations

* **Blazor Interactive Server:** Leveraged Blazor's interactive server rendering for a dynamic user experience without client-side JavaScript development.
* **Component-Based UI:** The `SearchComponent.razor` managing its state and UI updates.
* **Dependency Injection:** The `OMDbService` is injected into the Blazor component, for good architectural practices for service consumption.
* **Asynchronous Operations:** API calls are performed asynchronously using `async`/`await` to keep the UI responsive.
* **Model-View-Service Separation:** Clear separation of concerns with dedicated models for data, a service for API interaction, and the Blazor component for the view and its logic.
* **Basic Error Handling:** The `OMDbService` handles cases where no results are returned, preventing null reference exceptions and allowing the UI to display "No movies found." The `onerror` attribute on the image tag provides a fallback for missing poster images.

## Time Management & Future Enhancements

This project was developed within the allocated 2-hour time limit. The focus was on delivering core search functionality and a clean display of results. Several areas were identified for potential future enhancements if more time were available:

* **Robust API Key Management:** Move the OMDb API key from hardcoding into `appsettings.json` or user secrets for better security and environment-specific configuration.
* **Advanced Error Handling & User Feedback:**
    * Displaying specific error messages returned by the OMDb API( `response.Error` in `SearchResponse`).
* **Pagination:** The OMDb API supports pagination. Implementing this would be crucial for large result sets to improve performance and user experience.
* **Detail Page for Movies:** Clicking on a movie card could navigate to a new page (`/movie/{imdbID}`) to display more detailed information using the OMDb API's ID lookup (e.g., plot, cast, ratings).
* **Search by Type:** Add a dropdown or radio buttons to filter results by `movie`, `series`, or `episode` using the `type` parameter in the OMDb API.
* **Loading Spinners/Animations:** Replace the "Loading..." text with a more visually appealing loading spinner. 
* **Client-Side Caching:** Cache frequently searched results to reduce API calls and improve responsiveness.


