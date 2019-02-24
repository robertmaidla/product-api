Product API (.NET Core)

API has 3 endpoints:
 - GET /api/product  - Returns the full list of products in the database.
 - GET /api/product/{id} - Returns the product with the corresponding id parameter.
 - POST /api/product - Adds a new product to the database. Request body to be of type 'ProductItem'. 
    Name and group fields are mandatory. 2 of the following 3 parameters are required to calculate the 
    3rd one - price, priceWithVAT and VATRate.
 - GET /api/group - Returns the master node of 'GroupItem', which contains the tree of sub-groups.

