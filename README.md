# ContainerDemo
Containers and invoices
/*
Given a list of invoices
               Invoice => Id, Date, Due Date, Currency, Amount
Given a list of containers
               container => Id, StartDate, Start Time, EndDate, End Time, Currency, Min Tenor, Max Tenor, Max Limit
Design a system to process invoices in a way that they fit into correct containers
In order for an invoice to fit, the container needs to be active(between start and end times) and match currency
Question 1: Print container {Id} - Invoices [{Id}]
Question 2: Given Tenor = (DueDate - CurrentDate). Invoices should also fit into Min and Max Tenors
Question 3: Each container has a max limit, ensure that the addition of invoice always keeps the containers in balance
Eg: Two containers are active and have limits of 1 million and 3 Million each, containers are considered to be in balance if container 1 has invoices worth 500K and container 2 has invoices worth 1.5 million. If container 1 has 600K, then container 2 has 1.8 million
Question 4: A container can have multiple currencies and balances and max limit is per currency
*/
