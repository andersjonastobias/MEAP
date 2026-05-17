### Notes from MEAP
Simple standalone .NET application.
#### Initialize a Git repository and set up .gitignore
````
git init
echo "**/bin/" > .gitignore
echo "**/bin/" >> .gitignore
echo "**/bin/" >> .gitignore
````

#### Push to GitHub
````
git add .
git commit -m "Initial commit"
git remote add origin https://github.com/andersjonastobias/MEAP.git
git push -u origin master