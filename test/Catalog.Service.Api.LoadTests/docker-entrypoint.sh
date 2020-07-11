#!/bin/sh

java -Dlogback.configurationFile=logback.xml -jar rate-limiting-1.0.jar -s $1

if [[ "${ON_LOAD_TESTS_COMPLETED}" ]]; then
    echo "Executing ${ON_LOAD_TESTS_COMPLETED}"
    . ${ON_LOAD_TESTS_COMPLETED}
fi
