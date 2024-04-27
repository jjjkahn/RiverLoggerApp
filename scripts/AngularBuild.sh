#!/bin/sh
echo "Stating pipeline"
ls
cd RiverLoggerSpa
echo "Running npm ci"
npm ci
echo "Running Build"
npm run build --if-present
echo "Running Test"
npm test
