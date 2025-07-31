// Library Page JavaScript

document.addEventListener('DOMContentLoaded', function() {
    initSearch();
    initScrollEffects();
    initBookCards();
    initCategoryCards();
    initSmoothScrolling();
    initScrollAnimations();
    initLazyLoading();
    initKeyboardShortcuts();
});

// Search functionality
function initSearch() {
    const searchInput = document.querySelector('.hero-search-input');
    const searchBtn = document.querySelector('.search-btn');
    
    if (!searchInput || !searchBtn) return;
    
    function performSearch() {
        const query = searchInput.value.trim();
        if (query) {
            // Add loading state
            searchBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i>';
            searchBtn.disabled = true;
            
            // Simulate search delay
            setTimeout(() => {
                // Redirect to search page with query
                window.location.href = `/Books/Search?q=${encodeURIComponent(query)}`;
            }, 500);
        }
    }
    
    searchBtn.addEventListener('click', performSearch);
    searchInput.addEventListener('keypress', function(e) {
        if (e.key === 'Enter') {
            performSearch();
        }
    });
    
    // Auto-focus search input
    searchInput.focus();
}

// Horizontal scroll effects
function initScrollEffects() {
    const scrollContainers = document.querySelectorAll('.categories-scroll, .books-scroll');
    
    scrollContainers.forEach(container => {
        // Mouse wheel horizontal scroll
        container.addEventListener('wheel', function(e) {
            e.preventDefault();
            this.scrollLeft += e.deltaY;
        });
        
        // Touch drag scroll
        let isDown = false;
        let startX;
        let scrollLeft;
        
        container.addEventListener('mousedown', function(e) {
            isDown = true;
            this.style.cursor = 'grabbing';
            startX = e.pageX - this.offsetLeft;
            scrollLeft = this.scrollLeft;
        });
        
        container.addEventListener('mouseleave', function() {
            isDown = false;
            this.style.cursor = 'grab';
        });
        
        container.addEventListener('mouseup', function() {
            isDown = false;
            this.style.cursor = 'grab';
        });
        
        container.addEventListener('mousemove', function(e) {
            if (!isDown) return;
            e.preventDefault();
            const x = e.pageX - this.offsetLeft;
            const walk = (x - startX) * 2;
            this.scrollLeft = scrollLeft - walk;
        });
        
        // Add scroll indicators
        addScrollIndicators(container);
    });
}

// Add scroll indicators
function addScrollIndicators(container) {
    const indicator = document.createElement('div');
    indicator.className = 'scroll-indicator';
    indicator.innerHTML = '<i class="fas fa-chevron-right"></i>';
    indicator.style.cssText = `
        position: absolute;
        right: 10px;
        top: 50%;
        transform: translateY(-50%);
        background: rgba(255, 255, 255, 0.2);
        color: white;
        padding: 8px;
        border-radius: 50%;
        cursor: pointer;
        transition: all 0.3s ease;
        z-index: 10;
    `;
    
    container.style.position = 'relative';
    container.appendChild(indicator);
    
    indicator.addEventListener('click', function() {
        container.scrollBy({
            left: 300,
            behavior: 'smooth'
        });
    });
    
    // Show/hide indicator based on scroll position
    container.addEventListener('scroll', function() {
        const isAtEnd = this.scrollLeft + this.clientWidth >= this.scrollWidth - 10;
        indicator.style.opacity = isAtEnd ? '0' : '1';
    });
}

// Book card interactions
function initBookCards() {
    const bookCards = document.querySelectorAll('.book-card');
    
    bookCards.forEach(card => {
        card.addEventListener('click', function(e) {
            // Don't trigger if clicking on overlay button
            if (e.target.closest('.book-overlay')) return;
            
            const bookTitle = this.querySelector('h3').textContent;
            
            // Add loading animation
            this.style.transform = 'scale(0.95)';
            this.style.transition = 'transform 0.2s ease';
            
            setTimeout(() => {
                // Redirect to book detail page
                window.location.href = `/Books/Detail?title=${encodeURIComponent(bookTitle)}`;
            }, 200);
        });
        
        // Hover effects
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-8px) scale(1.02)';
        });
        
        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0) scale(1)';
        });
    });
}

// Category card interactions
function initCategoryCards() {
    const categoryCards = document.querySelectorAll('.category-card');
    
    categoryCards.forEach(card => {
        card.addEventListener('click', function() {
            const categoryName = this.querySelector('h3').textContent;
            
            // Add loading animation
            this.style.transform = 'scale(0.95)';
            this.style.transition = 'transform 0.2s ease';
            
            setTimeout(() => {
                // Redirect to category page
                window.location.href = `/Categories/${encodeURIComponent(categoryName)}`;
            }, 200);
        });
    });
}

// Smooth scrolling for anchor links
function initSmoothScrolling() {
    const anchorLinks = document.querySelectorAll('a[href^="#"]');
    
    anchorLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            const targetId = this.getAttribute('href').substring(1);
            const targetElement = document.getElementById(targetId);
            
            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

// Scroll animations
function initScrollAnimations() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };
    
    const observer = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);
    
    // Observe sections for fade-in animation
    const sections = document.querySelectorAll('.categories-section, .trending-section, .new-releases-section, .recommended-section');
    sections.forEach(section => {
        section.style.opacity = '0';
        section.style.transform = 'translateY(30px)';
        section.style.transition = 'opacity 0.6s ease, transform 0.6s ease';
        observer.observe(section);
    });
}

// Lazy loading for images
function initLazyLoading() {
    const imageObserver = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const img = entry.target;
                if (img.dataset.src) {
                    img.src = img.dataset.src;
                    img.removeAttribute('data-src');
                    imageObserver.unobserve(img);
                }
            }
        });
    });
    
    // Observe all book cover images
    const bookImages = document.querySelectorAll('.book-cover img[data-src]');
    bookImages.forEach(img => imageObserver.observe(img));
}

// Keyboard shortcuts
function initKeyboardShortcuts() {
    document.addEventListener('keydown', function(e) {
        // Ctrl+K to focus search
        if (e.ctrlKey && e.key === 'k') {
            e.preventDefault();
            const searchInput = document.querySelector('.hero-search-input');
            if (searchInput) {
                searchInput.focus();
            }
        }
        
        // ESC to clear search
        if (e.key === 'Escape') {
            const searchInput = document.querySelector('.hero-search-input');
            if (searchInput && document.activeElement === searchInput) {
                searchInput.value = '';
                searchInput.blur();
            }
        }
    });
} 