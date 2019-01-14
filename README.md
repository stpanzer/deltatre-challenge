Implementation notes:
For the backend, I utilized IMemoryCache to store the Products. It would be fairly simple to change the backing store to EntityFramework or other ORM, as the Product class is a simple POCO as most ORMs generally accept. 

The backend serves JSON, a format I assume would be widely consumable across all devices.

The user stories do not mention editing or deleting products from the catalog, however extending the controller for all CRUD operations would be trivial.

For the requirement that new products added appear without reloading, I implemented a simple setTimeout-based polling solution. A more complete solution might be based on WebSocket, although for a prototype setTimeout works fine.

To run frontend:

npm install
npm run serve 

To run backend:

dotnet run
