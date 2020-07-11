#!/bin/sh

java -Dlogback.configurationFile=logback.xml -jar catalog-load-tests-1.0.jar -s $1
