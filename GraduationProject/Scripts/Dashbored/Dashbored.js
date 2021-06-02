
/* Chart section */
var ctx = document.getElementById('myChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["W42", "W43", "W44", "W45", "W46", "W47", "W48"],
        datasets: [{
            data: [30, 90, 44, 60, 83, 90, 100],
            label: "Sold Units",
            borderColor: "#28a745",
            backgroundColor: "rgb(60,186,159,0.1)",
        }, {
            data: [4, 3, 2, 2, 3, 0, 1],
            label: "Canceled Units",
            borderColor: "#c70315",
            backgroundColor: "rgb(196,88,80,0.1)",
        }
        ]
    },
});


/* ProgressBar section */
var bar1 = new ProgressBar.SemiCircle(container1, {
    strokeWidth: 22,
    color: '#FFEA82',
    trailColor: '#eee',
    trailWidth: 22,
    easing: 'easeInOut',
    duration: 1400,
    svgStyle: null,
    text: {
        value: '',
        alignToBottom: false
    },
    from: { color: '#FFEA82' },
    to: { color: '#ED6A5A' },
    // Set default step function for all animate calls
    step: (state, bar1) => {
        bar1.path.setAttribute('stroke', state.color);
        var value = Math.round(bar1.value() * 100);
        if (value === 0) {
            bar1.setText('');
        } else {
            bar1.setText(value);
        }

        bar1.text.style.color = state.color;
    }
});
bar1.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
bar1.text.style.fontSize = '1.5rem';
bar1.text.style.margin = '1rem auto';

bar1.animate(0.5);  // Number from 0.0 to 1.0

var bar2 = new ProgressBar.SemiCircle(container2, {
    strokeWidth: 22,
    color: '#FFEA82',
    trailColor: '#eee',
    trailWidth: 22,
    easing: 'easeInOut',
    duration: 1400,
    svgStyle: null,
    text: {
        value: '',
        alignToBottom: false
    },
    from: { color: '#FFEA82' },
    to: { color: '#ED6A5A' },
    // Set default step function for all animate calls
    step: (state, bar2) => {
        bar2.path.setAttribute('stroke', state.color);
        var value = Math.round(bar2.value() * 100);
        if (value === 0) {
            bar2.setText('');
        } else {
            bar2.setText(value);
        }

        bar2.text.style.color = state.color;
    }
});
bar2.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
bar2.text.style.fontSize = '1.8rem';
bar2.text.style.margin = '1rem auto';

bar2.animate(0.1);  // Number from 0.0 to 1.0

var bar3 = new ProgressBar.SemiCircle(container3, {
    strokeWidth: 22,
    color: '#FFEA82',
    trailColor: '#eee',
    trailWidth: 22,
    easing: 'easeInOut',
    duration: 1400,
    svgStyle: null,
    text: {
        value: '',
        alignToBottom: false
    },
    from: { color: '#FFEA82' },
    to: { color: '#ED6A5A' },
    // Set default step function for all animate calls
    step: (state, bar3) => {
        bar3.path.setAttribute('stroke', state.color);
        var value = Math.round(bar3.value() * 100);
        if (value === 0) {
            bar3.setText('');
        } else {
            bar3.setText(value);
        }

        bar3.text.style.color = state.color;
    }
});
bar3.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
bar3.text.style.fontSize = '1.5rem';
bar3.text.style.margin = '1rem auto';

bar3.animate(0.8);  // Number from 0.0 to 1.0    

var bar4 = new ProgressBar.SemiCircle(container4, {
    strokeWidth: 22,
    color: '#FFEA82',
    trailColor: '#eee',
    trailWidth: 22,
    easing: 'easeInOut',
    duration: 1400,
    svgStyle: null,
    text: {
        value: '',
        alignToBottom: false
    },
    from: { color: '#FFEA82' },
    to: { color: '#ED6A5A' },
    // Set default step function for all animate calls
    step: (state, bar4) => {
        bar4.path.setAttribute('stroke', state.color);
        var value = Math.round(bar4.value() * 100);
        if (value === 0) {
            bar4.setText('');
        } else {
            bar4.setText(value);
        }

        bar4.text.style.color = state.color;
    }
});
bar4.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
bar4.text.style.fontSize = '1.5rem';
bar4.text.style.margin = '1rem auto';

bar4.animate(0.3);  // Number from 0.0 to 1.0     

