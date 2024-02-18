#!/bin/bash

./run.build.sh

sleep 1

git add .
git commit -m "📦 Struct: Build."

sleep 1

git push origin
git push server

sleep 1
