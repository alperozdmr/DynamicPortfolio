pipeline {
    agent any

    environment {
        COMPOSE_PROJECT_NAME = 'portfolio'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Docker Images') {
            steps {
                // Jenkins Credentials Manager uzerinden PROD_ENV_FILE adinda bir 'Secret file' eklendi.
                withCredentials([file(credentialsId: 'PROD_ENV_FILE', variable: 'SECURE_ENV_FILE')]) {
                    sh 'cp $SECURE_ENV_FILE .env.production'
                }
                sh 'docker compose --env-file .env.production -f docker-compose.prod.yml build'
            }
        }

        stage('Stop Previous Containers') {
            steps {
                sh 'docker compose --env-file .env.production -f docker-compose.prod.yml down -v --remove-orphans || true'
            }
        }

        stage('Deploy') {
            steps {
                sh 'docker compose --env-file .env.production -f docker-compose.prod.yml up -d'
            }
        }
    }

    post {
        failure {
            echo 'Pipeline failed. Collecting logs...'
            sh 'docker compose --env-file .env.production -f docker-compose.prod.yml logs || true'
            sh 'docker compose --env-file .env.production -f docker-compose.prod.yml down -v --remove-orphans || true'
            sh 'rm -f .env.production || true' // Temizlik
        }
        success {
            echo 'Deployment successful!'
            echo 'UI:  http://localhost:5000'
            //echo 'API: http://localhost:5001/swagger'
            sh 'rm -f .env.production || true' // Temizlik
        }
    }
}
