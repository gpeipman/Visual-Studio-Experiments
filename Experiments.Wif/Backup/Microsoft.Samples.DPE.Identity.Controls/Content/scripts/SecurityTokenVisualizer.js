function toggleVisualizerVisibility(visualizerId, visualizerImageId, expandedImgSrc, collapsedImgSrc) {
    visualizer = document.getElementById(visualizerId);
    visualizerImage = document.getElementById(visualizerImageId);
    
    if (visualizer != null) {
        if (visualizer.style.display == "none") {
            visualizer.style.display = "block";
            visualizerImage.src = expandedImgSrc;
        }
        else {
            visualizer.style.display = "none";
            visualizerImage.src = collapsedImgSrc;
        }
    }
}