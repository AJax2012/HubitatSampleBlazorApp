# Hubitat Blazor App

This project shows a simple blazor app using Hubitat Maker API.
To use this project, clone it using
`git clone https://github.com/AJax2012/HubitatSampleBlazorApp`,
then go to the appsettings.json file and change the values in the `HubitatApiInfo` object.
You can find the details in the MakerApi page on your Hubitat device. I didn't know what the "random string" was called in Hubitat, but it is the value directly after `/api/` and before `/apps/` in your cloud URLS section.

The button changes values based on Hubitat's actual value. I have only configured the project to refresh this string when the project starts and when the `SendRequest` function is called/button is pressed. This idea of this app was to create a blazor app using an API I enjoy using, not to create something fully functional.