let searchBar = document.getElementById('search-bar');
searchBar.addEventListener('input', () => {
    searchBar.style.height = 'auto';
    searchBar.style.height = (searchBar.scrollHeight) + 'px';
    searchBar.style.paddingBottom = '10px';
});

function triggerInputEvent() {
    var searchBar = document.getElementById('search-bar');
    if (searchBar) {
        var event = new Event('input', {
            bubbles: true,
            cancelable: true,
        });
        searchBar.dispatchEvent(event);
    }
}