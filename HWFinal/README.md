### Run Prerequisites (in order yo avoid errors)
sudo sysctl -w vm.max_map_count=262144

sudo systemctl restart docker

### Build image for the app we created
docker-compose build simplewebapp

### Start all services
docker-compose up -d

### Services URL's
simplewebapp: http://localhost:5000/swagger/index.html

SonarQube: http://localhost:9000

Jenkins: http://localhost:8080

Nexus: http://localhost:8081

Portainer: http://localhost:9443