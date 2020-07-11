docker run `
    -it `
    --rm `
    -v ${PWD}/target:/opt/app `
    -w /opt/app `
    --env LOAD_TESTS_BASE_URL=http://host.docker.internal:6969 `
    adoptopenjdk/openjdk8:alpine-slim java `
        "-Dlogback.configurationFile=logback.xml" `
        -jar catalog-load-tests-1.0.jar `
        -s loadtests.catalog.BrowseCatalogSimulation

# https://gatling.io/docs/current/general/configuration#command-line-options