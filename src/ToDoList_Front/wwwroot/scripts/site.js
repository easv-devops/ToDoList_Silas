function switchTheme(isDark) {
    if (isDark) {
        document.documentElement.style.setProperty('--background-color', '#2a2a2a');
    } else {
        document.documentElement.style.setProperty('--background-color', '#f6f6f6');
    }
}