# Rocket Elevators Customer Portal

This week we were assigned with the task of creating a separate web application for the customers of Rocket Elevators on the **.Net** platform using **MVC**. 

## Authentication

The website is hidden behind the Identity framework and the proper credentials must be provided in order to gain access: 

> Username: kendall@monahan-green.com
> Password: Password1!

Feel free to test the functionality of the website by trying to create a password from an email that does not correspond to a customer and then one that does. 

Passwords must:

 - Be at least 6 characters long
 - Contain at least 1 uppercase letter
 - Contain at least 1 number
 - Contain at least 1 special character

## Custom Domain

Unfortunately with the free tier of Azure, it is not possible to create custom domains. I tried purchasing a domain name from Namecheap and re-routing the name to Azure while masking the address bar URL but for some reason this does not work. There is still re-routing but the the Azure URL shows up in the address bar when you finally land on the page.