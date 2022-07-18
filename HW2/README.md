### Image creation
docker build . -t simplewebapp

### Run Container
docker run --name simplewebapp -p 5000:5000 -d simplewebapp

### Lunch app
http://localhost:5000/swagger/index.html