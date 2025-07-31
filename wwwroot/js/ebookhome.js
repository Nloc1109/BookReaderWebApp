// E-BOOKS PAGE JAVASCRIPT

document.addEventListener('DOMContentLoaded', function() {
    // Search functionality
    const searchInput = document.querySelector('.hero-search-input');
    const searchBtn = document.querySelector('.search-btn');
    
    if (searchInput && searchBtn) {
        // Search button click
        searchBtn.addEventListener('click', function() {
            performSearch();
        });
        
        // Enter key press
        searchInput.addEventListener('keypress', function(e) {
            if (e.key === 'Enter') {
                performSearch();
            }
        });
        
        // Search input focus effect
        searchInput.addEventListener('focus', function() {
            this.parentElement.style.transform = 'scale(1.02)';
        });
        
        searchInput.addEventListener('blur', function() {
            this.parentElement.style.transform = 'scale(1)';
        });
    }
    
    function performSearch() {
        const query = searchInput.value.trim();
        if (query) {
            // Show loading state
            searchBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i>';
            searchBtn.disabled = true;
            
            // Simulate search delay
            setTimeout(() => {
                // Reset button
                searchBtn.innerHTML = '<i class="fas fa-search"></i>';
                searchBtn.disabled = false;
                
                // Show search results (you can implement actual search logic here)
                showNotification(`Đang tìm kiếm: "${query}"`, 'info');
            }, 1000);
        }
    }
    
    // Featured E-books hover effects
    const featuredCards = document.querySelectorAll('.featured-ebook-card');
    featuredCards.forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-10px) scale(1.02)';
        });
        
        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0) scale(1)';
        });
    });
    
    // Read buttons functionality
    const readButtons = document.querySelectorAll('.read-btn');
    readButtons.forEach(btn => {
        btn.addEventListener('click', function(e) {
            e.preventDefault();
            const card = this.closest('.featured-ebook-card');
            const title = card.querySelector('h3').textContent;
            
            // Show loading state
            const originalText = this.innerHTML;
            this.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang mở...';
            this.disabled = true;
            
            // Simulate opening book
            setTimeout(() => {
                this.innerHTML = originalText;
                this.disabled = false;
                showNotification(`Đang mở sách: "${title}"`, 'success');
            }, 1500);
        });
    });
    
    // New releases scroll functionality
    const newReleasesScroll = document.querySelector('.new-releases-scroll');
    if (newReleasesScroll) {
        let isScrolling = false;
        
        // Smooth scroll on wheel
        newReleasesScroll.addEventListener('wheel', function(e) {
            e.preventDefault();
            if (!isScrolling) {
                isScrolling = true;
                this.scrollLeft += e.deltaY;
                setTimeout(() => {
                    isScrolling = false;
                }, 100);
            }
        });
        
        // Touch scroll for mobile
        let startX, scrollLeft;
        newReleasesScroll.addEventListener('touchstart', function(e) {
            startX = e.touches[0].pageX - this.offsetLeft;
            scrollLeft = this.scrollLeft;
        });
        
        newReleasesScroll.addEventListener('touchmove', function(e) {
            if (!startX) return;
            e.preventDefault();
            const x = e.touches[0].pageX - this.offsetLeft;
            const walk = (x - startX) * 2;
            this.scrollLeft = scrollLeft - walk;
        });
        
        newReleasesScroll.addEventListener('touchend', function() {
            startX = null;
        });
    }
    
    // New release cards click functionality
    const newReleaseCards = document.querySelectorAll('.new-release-card');
    newReleaseCards.forEach(card => {
        card.addEventListener('click', function() {
            const title = this.querySelector('h4').textContent;
            const author = this.querySelector('.release-author').textContent;
            
            // Add click animation
            this.style.transform = 'scale(0.95)';
            setTimeout(() => {
                this.style.transform = 'scale(1)';
            }, 150);
            
            showNotification(`Xem chi tiết: "${title}" - ${author}`, 'info');
        });
    });
    
    // Feature cards hover effects
    const featureCards = document.querySelectorAll('.feature-card');
    featureCards.forEach(card => {
        card.addEventListener('mouseenter', function() {
            const icon = this.querySelector('.feature-icon');
            icon.style.transform = 'scale(1.1) rotate(5deg)';
        });
        
        card.addEventListener('mouseleave', function() {
            const icon = this.querySelector('.feature-icon');
            icon.style.transform = 'scale(1) rotate(0deg)';
        });
    });
    
    // CTA button functionality
    const ctaButton = document.querySelector('.cta-button');
    if (ctaButton) {
        ctaButton.addEventListener('click', function(e) {
            e.preventDefault();
            
            // Show loading state
            const originalText = this.innerHTML;
            this.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang chuyển hướng...';
            this.disabled = true;
            
            // Simulate redirect
            setTimeout(() => {
                this.innerHTML = originalText;
                this.disabled = false;
                showNotification('Chuyển hướng đến trang đọc sách!', 'success');
            }, 2000);
        });
    }
    
    // Device showcase animation
    const devices = document.querySelectorAll('.device');
    devices.forEach((device, index) => {
        device.addEventListener('mouseenter', function() {
            this.style.transform = 'scale(1.2)';
            this.style.zIndex = '10';
        });
        
        device.addEventListener('mouseleave', function() {
            this.style.transform = 'scale(1)';
            this.style.zIndex = '1';
        });
    });
    
    // Floating books animation enhancement
    const floatingBooks = document.querySelectorAll('.floating-book');
    floatingBooks.forEach(book => {
        book.addEventListener('mouseenter', function() {
            this.style.transform = 'scale(1.2) rotate(10deg)';
            this.style.zIndex = '10';
        });
        
        book.addEventListener('mouseleave', function() {
            this.style.transform = 'scale(1) rotate(0deg)';
            this.style.zIndex = '1';
        });
    });
    
    // Preview items click functionality
    const previewItems = document.querySelectorAll('.preview-item');
    previewItems.forEach(item => {
        item.addEventListener('click', function() {
            const category = this.querySelector('span').textContent;
            showNotification(`Chuyển đến thể loại: ${category}`, 'info');
        });
    });
    
    // View all buttons functionality
    const viewAllButtons = document.querySelectorAll('.view-all-btn');
    viewAllButtons.forEach(btn => {
        btn.addEventListener('click', function(e) {
            e.preventDefault();
            const section = this.closest('section');
            const title = section.querySelector('h2').textContent;
            
            // Show loading state
            const originalText = this.innerHTML;
            this.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang tải...';
            this.disabled = true;
            
            setTimeout(() => {
                this.innerHTML = originalText;
                this.disabled = false;
                showNotification(`Chuyển đến: ${title}`, 'success');
            }, 1500);
        });
    });
    
    // Notification system
    function showNotification(message, type = 'info') {
        // Create notification element
        const notification = document.createElement('div');
        notification.className = `notification notification-${type}`;
        notification.innerHTML = `
            <div class="notification-content">
                <i class="fas fa-${type === 'success' ? 'check-circle' : type === 'error' ? 'exclamation-circle' : 'info-circle'}"></i>
                <span>${message}</span>
            </div>
            <button class="notification-close">
                <i class="fas fa-times"></i>
            </button>
        `;
        
        // Add styles
        notification.style.cssText = `
            position: fixed;
            top: 20px;
            right: 20px;
            background: ${type === 'success' ? '#10b981' : type === 'error' ? '#ef4444' : '#3b82f6'};
            color: white;
            padding: 1rem 1.5rem;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
            z-index: 1000;
            display: flex;
            align-items: center;
            gap: 1rem;
            max-width: 400px;
            transform: translateX(100%);
            transition: transform 0.3s ease;
        `;
        
        // Add to page
        document.body.appendChild(notification);
        
        // Animate in
        setTimeout(() => {
            notification.style.transform = 'translateX(0)';
        }, 100);
        
        // Close button functionality
        const closeBtn = notification.querySelector('.notification-close');
        closeBtn.addEventListener('click', () => {
            notification.style.transform = 'translateX(100%)';
            setTimeout(() => {
                document.body.removeChild(notification);
            }, 300);
        });
        
        // Auto remove after 5 seconds
        setTimeout(() => {
            if (document.body.contains(notification)) {
                notification.style.transform = 'translateX(100%)';
                setTimeout(() => {
                    if (document.body.contains(notification)) {
                        document.body.removeChild(notification);
                    }
                }, 300);
            }
        }, 5000);
    }
    
    // Intersection Observer for animations
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };
    
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);
    
    // Observe all cards and sections
    const animatedElements = document.querySelectorAll('.featured-ebook-card, .feature-card, .new-release-card, .section-header');
    animatedElements.forEach(el => {
        el.style.opacity = '0';
        el.style.transform = 'translateY(30px)';
        el.style.transition = 'opacity 0.6s ease, transform 0.6s ease';
        observer.observe(el);
    });
    
    // Page load animation
    setTimeout(() => {
        document.body.style.opacity = '1';
    }, 100);
});

// Add CSS for notifications
const notificationStyles = `
<style>
.notification-content {
    display: flex;
    align-items: center;
    gap: 0.75rem;
}

.notification-close {
    background: none;
    border: none;
    color: white;
    cursor: pointer;
    padding: 0.25rem;
    border-radius: 4px;
    transition: background-color 0.2s ease;
}

.notification-close:hover {
    background: rgba(255, 255, 255, 0.2);
}

@media (max-width: 768px) {
    .notification {
        top: 10px !important;
        right: 10px !important;
        left: 10px !important;
        max-width: none !important;
    }
}
</style>
`;

// Inject styles
document.head.insertAdjacentHTML('beforeend', notificationStyles); 