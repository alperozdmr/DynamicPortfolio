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
                sh 'docker compose -f docker-compose.prod.yml build'
            }
        }

        stage('Stop Previous Containers') {
            steps {
                sh 'docker compose -f docker-compose.prod.yml down -v --remove-orphans || true'
            }
        }

        stage('Deploy') {
            steps {
                sh 'docker compose -f docker-compose.prod.yml up -d'
            }
        }

        // stage('Health Check') {
        //     steps {
        //         script {
        //             def maxRetries = 12
        //             def retryInterval = 10  // seconds
        //             def healthy = false

        //             for (int i = 1; i <= maxRetries; i++) {
        //                 try {
        //                     sh "curl -f -L -s -o /prod/null http://localhost:5000"
        //                     echo "Health check passed on attempt ${i}"
        //                     healthy = true
        //                     break
        //                 } catch (Exception e) {
        //                     echo "Health check attempt ${i}/${maxRetries} failed. Retrying in ${retryInterval}s..."
        //                     sleep retryInterval
        //                 }
        //             }

        //             if (!healthy) {
        //                 sh 'docker compose -f docker-compose.prod.yml logs'
        //                 error 'Application failed to become healthy within the expected time.'
        //             }
        //         }
        //     }
        // }
    }

    post {
        failure {
            echo 'Pipeline failed. Collecting logs...'
            sh 'docker compose -f docker-compose.prod.yml logs || true'
            sh 'docker compose -f docker-compose.prod.yml down -v --remove-orphans || true'
        }
        success {
            echo 'Deployment successful!'
            echo 'UI:  http://localhost:5000'
            //echo 'API: http://localhost:5001/swagger'
        }
    }
}
