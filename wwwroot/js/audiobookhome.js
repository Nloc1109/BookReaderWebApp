// Audiobookhome Page JavaScript
document.addEventListener('DOMContentLoaded', function() {
    initializeSearch();
    initializePlayButtons();
    initializeScrollEffects();
    initializeNotifications();
    initializeAudioPlayer();
});

// Search functionality
function initializeSearch() {
    const searchInput = document.querySelector('.hero-search-input');
    const searchBtn = document.querySelector('.search-btn');
    
    if (searchInput && searchBtn) {
        let searchTimeout;
        
        searchInput.addEventListener('input', function() {
            clearTimeout(searchTimeout);
            searchTimeout = setTimeout(() => {
                performSearch(this.value);
            }, 300);
        });
        
        searchBtn.addEventListener('click', function() {
            performSearch(searchInput.value);
        });
        
        searchInput.addEventListener('keypress', function(e) {
            if (e.key === 'Enter') {
                performSearch(this.value);
            }
        });
    }
}

function performSearch(query) {
    if (!query.trim()) return;
    
    console.log('Searching for:', query);
    showNotification(`Đang tìm kiếm: "${query}"`, 'info');
    
    setTimeout(() => {
        showNotification(`Tìm thấy 15 kết quả cho "${query}"`, 'success');
    }, 1000);
}

// Play buttons functionality
function initializePlayButtons() {
    const playButtons = document.querySelectorAll('.play-btn, .play-sample-btn');
    
    playButtons.forEach(button => {
        button.addEventListener('click', function(e) {
            e.preventDefault();
            e.stopPropagation();
            
            const card = this.closest('.book-card, .narrator-card');
            const title = card?.querySelector('h3')?.textContent || 'Sách nói';
            
            // Toggle play/pause icon
            const icon = this.querySelector('i');
            if (icon.classList.contains('fa-play')) {
                icon.classList.remove('fa-play');
                icon.classList.add('fa-pause');
                showNotification(`Đang phát: ${title}`, 'success');
            } else {
                icon.classList.remove('fa-pause');
                icon.classList.add('fa-play');
                showNotification(`Đã tạm dừng: ${title}`, 'info');
            }
        });
    });
}

// Audio Player Demo functionality
function initializeAudioPlayer() {
    const playDemoBtn = document.querySelector('.play-demo-btn');
    const playBtn = document.querySelector('.player-controls .play-btn');
    const progressFill = document.querySelector('.progress-fill');
    const currentTime = document.querySelector('.current-time');
    const totalTime = document.querySelector('.total-time');
    
    let isPlaying = false;
    let currentProgress = 30; // Start at 30%
    
    if (playDemoBtn) {
        playDemoBtn.addEventListener('click', function() {
            togglePlay();
        });
    }
    
    if (playBtn) {
        playBtn.addEventListener('click', function() {
            togglePlay();
        });
    }
    
    function togglePlay() {
        isPlaying = !isPlaying;
        const icon = playDemoBtn?.querySelector('i') || playBtn?.querySelector('i');
        
        if (icon) {
            if (isPlaying) {
                icon.classList.remove('fa-play');
                icon.classList.add('fa-pause');
                showNotification('Đang phát: Đắc Nhân Tâm - Chương 1', 'success');
                startProgress();
            } else {
                icon.classList.remove('fa-pause');
                icon.classList.add('fa-play');
                showNotification('Đã tạm dừng', 'info');
                stopProgress();
            }
        }
    }
    
    function startProgress() {
        const interval = setInterval(() => {
            if (!isPlaying) {
                clearInterval(interval);
                return;
            }
            
            currentProgress += 0.5;
            if (currentProgress > 100) {
                currentProgress = 0;
            }
            
            if (progressFill) {
                progressFill.style.width = currentProgress + '%';
            }
            
            if (currentTime) {
                const minutes = Math.floor((currentProgress / 100) * 3.75);
                const seconds = Math.floor(((currentProgress / 100) * 3.75 - minutes) * 60);
                currentTime.textContent = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
            }
        }, 1000);
        
        // Store interval for cleanup
        window.audioProgressInterval = interval;
    }
    
    function stopProgress() {
        if (window.audioProgressInterval) {
            clearInterval(window.audioProgressInterval);
        }
    }
    
    // Control buttons
    const controlBtns = document.querySelectorAll('.control-btn:not(.play-btn)');
    controlBtns.forEach(btn => {
        btn.addEventListener('click', function() {
            const icon = this.querySelector('i');
            if (icon.classList.contains('fa-backward')) {
                currentProgress = Math.max(0, currentProgress - 10);
                showNotification('Lùi 10 giây', 'info');
            } else if (icon.classList.contains('fa-forward')) {
                currentProgress = Math.min(100, currentProgress + 10);
                showNotification('Tới 10 giây', 'info');
            } else if (icon.classList.contains('fa-volume-up')) {
                showNotification('Điều chỉnh âm lượng', 'info');
            }
            
            if (progressFill) {
                progressFill.style.width = currentProgress + '%';
            }
        });
    });
}

// Scroll effects
function initializeScrollEffects() {
    // Smooth scroll for anchor links
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
    
    // Horizontal scroll for book and narrator sections
    const scrollContainers = document.querySelectorAll('.books-scroll, .narrators-scroll');
    scrollContainers.forEach(container => {
        let isDown = false;
        let startX;
        let scrollLeft;
        
        container.addEventListener('mousedown', (e) => {
            isDown = true;
            container.style.cursor = 'grabbing';
            startX = e.pageX - container.offsetLeft;
            scrollLeft = container.scrollLeft;
        });
        
        container.addEventListener('mouseleave', () => {
            isDown = false;
            container.style.cursor = 'grab';
        });
        
        container.addEventListener('mouseup', () => {
            isDown = false;
            container.style.cursor = 'grab';
        });
        
        container.addEventListener('mousemove', (e) => {
            if (!isDown) return;
            e.preventDefault();
            const x = e.pageX - container.offsetLeft;
            const walk = (x - startX) * 2;
            container.scrollLeft = scrollLeft - walk;
        });
    });
}

// Notification system
function initializeNotifications() {
    if (!document.querySelector('.notification-container')) {
        const notificationContainer = document.createElement('div');
        notificationContainer.className = 'notification-container';
        document.body.appendChild(notificationContainer);
    }
}

function showNotification(message, type = 'info') {
    const container = document.querySelector('.notification-container');
    if (!container) return;
    
    const notification = document.createElement('div');
    notification.className = `notification notification-${type}`;
    notification.innerHTML = `
        <div class="notification-content">
            <i class="fas ${getNotificationIcon(type)}"></i>
            <span>${message}</span>
        </div>
        <button class="notification-close">
            <i class="fas fa-times"></i>
        </button>
    `;
    
    container.appendChild(notification);
    
    setTimeout(() => {
        notification.classList.add('show');
    }, 100);
    
    setTimeout(() => {
        removeNotification(notification);
    }, 3000);
    
    const closeBtn = notification.querySelector('.notification-close');
    closeBtn.addEventListener('click', () => {
        removeNotification(notification);
    });
}

function removeNotification(notification) {
    notification.classList.remove('show');
    setTimeout(() => {
        if (notification.parentNode) {
            notification.parentNode.removeChild(notification);
        }
    }, 300);
}

function getNotificationIcon(type) {
    switch (type) {
        case 'success': return 'fa-check-circle';
        case 'error': return 'fa-exclamation-circle';
        case 'warning': return 'fa-exclamation-triangle';
        default: return 'fa-info-circle';
    }
}

// Add notification styles
const notificationStyles = `
<style>
.notification-container {
    position: fixed;
    top: 20px;
    right: 20px;
    z-index: 10000;
    display: flex;
    flex-direction: column;
    gap: 10px;
}

.notification {
    background: rgba(255, 255, 255, 0.95);
    border: 1px solid rgba(0, 0, 0, 0.1);
    border-radius: 8px;
    padding: 1rem 1.5rem;
    box-shadow: 0 10px 25px rgba(0, 0, 0, 0.15);
    display: flex;
    align-items: center;
    justify-content: space-between;
    min-width: 300px;
    transform: translateX(100%);
    transition: transform 0.3s ease;
    backdrop-filter: blur(10px);
}

.notification.show {
    transform: translateX(0);
}

.notification-content {
    display: flex;
    align-items: center;
    gap: 0.75rem;
    flex: 1;
}

.notification-content i {
    font-size: 1.1rem;
}

.notification-success .notification-content i {
    color: #10b981;
}

.notification-error .notification-content i {
    color: #ef4444;
}

.notification-warning .notification-content i {
    color: #f59e0b;
}

.notification-info .notification-content i {
    color: #3b82f6;
}

.notification-close {
    background: transparent;
    border: none;
    color: #64748b;
    cursor: pointer;
    padding: 0.25rem;
    border-radius: 4px;
    transition: all 0.3s ease;
}

.notification-close:hover {
    color: #1e293b;
    background: rgba(0, 0, 0, 0.05);
}

@media (max-width: 768px) {
    .notification-container {
        top: 10px;
        right: 10px;
        left: 10px;
    }
    
    .notification {
        min-width: auto;
    }
}
</style>
`;

// Inject notification styles
if (!document.querySelector('#notification-styles')) {
    const styleElement = document.createElement('style');
    styleElement.id = 'notification-styles';
    styleElement.textContent = notificationStyles;
    document.head.appendChild(styleElement);
}

// Hover effects for cards
document.addEventListener('DOMContentLoaded', function() {
    const cards = document.querySelectorAll('.book-card, .narrator-card, .feature-card');
    
    cards.forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-5px) scale(1.02)';
        });
        
        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0) scale(1)';
        });
    });
});

// Keyboard navigation
document.addEventListener('keydown', function(e) {
    if (e.code === 'Escape') {
        const notifications = document.querySelectorAll('.notification.show');
        notifications.forEach(notification => {
            removeNotification(notification);
        });
    }
});

// Intersection Observer for animations
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

// Observe elements for animation
document.addEventListener('DOMContentLoaded', function() {
    const animatedElements = document.querySelectorAll('.book-card, .narrator-card, .feature-card, .section-header, .player-card');
    
    animatedElements.forEach(el => {
        el.style.opacity = '0';
        el.style.transform = 'translateY(20px)';
        el.style.transition = 'opacity 0.6s ease, transform 0.6s ease';
        observer.observe(el);
    });
});

// Performance optimization
function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

// Optimize scroll events
const optimizedScrollHandler = debounce(function() {
    // Scroll-based animations and effects
}, 16);

window.addEventListener('scroll', optimizedScrollHandler);

// Cleanup on page unload
window.addEventListener('beforeunload', function() {
    observer.disconnect();
    window.removeEventListener('scroll', optimizedScrollHandler);
    if (window.audioProgressInterval) {
        clearInterval(window.audioProgressInterval);
    }
}); 