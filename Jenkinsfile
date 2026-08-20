pipeline {
    agent any

    stages {

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build -c Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish JenkinsWebApi.csproj -c Release -o publish'
            }
        }

        stage('Deploy DEV') {
            steps {
                bat '''
                if exist "C:\\Users\\ashaikh\\OneDrive - ARCHER Systems LLC\\Desktop\\practice\\practice\\Deployments\\DEV" (
                    rmdir /s /q "C:\\Users\\ashaikh\\OneDrive - ARCHER Systems LLC\\Desktop\\practice\\practice\\Deployments\\DEV"
                )

                mkdir "C:\\Users\\ashaikh\\OneDrive - ARCHER Systems LLC\\Desktop\\practice\\practice\\Deployments\\DEV"

                xcopy publish\\* "C:\\Users\\ashaikh\\OneDrive - ARCHER Systems LLC\\Desktop\\practice\\practice\\Deployments\\DEV\\" /E /I /Y
                '''
            }
        }
    }
}