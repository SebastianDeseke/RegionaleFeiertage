#!/bin/bash

# Run this on VPS after the initial deployment

DOMAIN="sebastianstudio.de"

echo "🔒 Setting up SSL certificate for $DOMAIN..."

# Install Certbot if not already installed
if ! command -v certbot &> /dev/null; then
    echo "📦 Installing Certbot..."
    sudo apt update
    sudo apt install certbot python3-certbot-nginx -y
fi

# Obtain SSL certificate
echo "🎫 Obtaining SSL certificate..."
sudo certbot --nginx -d $DOMAIN -d www.$DOMAIN

# Test automatic renewal
echo "🔄 Testing automatic renewal..."
sudo certbot renew --dry-run

echo "✅ SSL setup completed!"
echo "🌐 Your API is now available at: https://$DOMAIN/api/"