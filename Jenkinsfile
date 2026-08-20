pipeline {
    agent any

    parameters {
        choice(
            name: 'ENVIRONMENT',
            choices: ['DEV', 'STAGE', 'UAT'],
            description: 'Select deployment environment'
        )
    }

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

        stage('Deploy') {
            steps {
                script {

                    def targetFolder = "C:\\Users\\ashaikh\\OneDrive - ARCHER Systems LLC\\Desktop\\practice\\practice\\Deployments\\${params.ENVIRONMENT}"

                    bat """
                    if exist "${targetFolder}" (
                        rmdir /s /q "${targetFolder}"
                    )

                    mkdir "${targetFolder}"

                    xcopy publish\\* "${targetFolder}\\" /E /I /Y
                    """
                }
            }
        }
    }
}