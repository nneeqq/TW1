function randomNumber(a, e) { return Math.random() * (e - a) + a }

function randomBar(a, e) {
    var o = randomNumber(.95 * e, 1.05 * e), t = randomNumber(.95 * o, 1.05 * o);
    return{ t: a.valueOf(), y: t }
}

!function(d) {
    "use strict";
    var a = function() { this.$body = d("body"), this.charts = [] };
    a.prototype.respChart = function(e, o, t, r) {
        Chart.defaults.global.defaultFontColor = "rgba(255,255,255,0.5)", Chart.defaults.scale.gridLines.color =
            "rgba(255,255,255,0.05)";
        var l = e.get(0).getContext("2d"), n = d(e).parent();
        return function() {
            var a;
            switch (e.attr("width", d(n).width()), o) {
            case"Line":
                a = new Chart(l, { type: "line", data: t, options: r });
                break;
            case"Doughnut":
                a = new Chart(l, { type: "doughnut", data: t, options: r });
                break;
            case"Pie":
                a = new Chart(l, { type: "pie", data: t, options: r });
                break;
            case"Bar":
                a = new Chart(l, { type: "bar", data: t, options: r });
                break;
            case"Radar":
                a = new Chart(l, { type: "radar", data: t, options: r });
                break;
            case"PolarArea":
                a = new Chart(l, { data: t, type: "polarArea", options: r })
            }
            return a
        }()
    }, a.prototype.initCharts = function() {
        var a = [];
        if (0 < d("#line-chart-example").length) {
            a.push(this.respChart(d("#line-chart-example"),
                "Line",
                {
                    labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
                    datasets: [
                        {
                            label: "Current Week",
                            backgroundColor: "rgba(59, 175, 218, 0.3)",
                            borderColor: "#3bafda",
                            data: [32, 42, 42, 62, 52, 75, 62]
                        },
                        {
                            label: "Previous Week",
                            fill: !0,
                            backgroundColor: "transparent",
                            borderColor: "#f672a7",
                            borderDash: [5, 5],
                            data: [42, 58, 66, 93, 82, 105, 92]
                        }
                    ]
                },
                {
                    maintainAspectRatio: !1,
                    legend: { display: !1 },
                    tooltips: {
                        backgroundColor: "#dee2e6",
                        titleFontColor: "#5089de",
                        bodyFontColor: "#000",
                        bodyFontSize: 14,
                        displayColors: !1
                    },
                    hover: { intersect: !0 },
                    plugins: { filler: { propagate: !1 } },
                    scales: {
                        xAxes: [{ reverse: !0, gridLines: { color: "rgba(255,255,255,0.03)" } }],
                        yAxes: [
                            {
                                ticks: { stepSize: 20 },
                                display: !0,
                                borderDash: [5, 5],
                                gridLines: { color: "rgba(0,0,0,0)", fontColor: "#fff" }
                            }
                        ]
                    }
                }))
        }
        if (0 < d("#bar-chart-example").length) {
            a.push(this.respChart(d("#bar-chart-example"),
                "Bar",
                {
                    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                    datasets: [
                        {
                            label: "Sales Analytics",
                            backgroundColor: "#1abc9c",
                            borderColor: "#1abc9c",
                            hoverBackgroundColor: "#1abc9c",
                            hoverBorderColor: "#1abc9c",
                            data: [65, 59, 80, 81, 56, 89, 40, 32, 65, 59, 80, 81]
                        },
                        {
                            label: "Dollar Rate",
                            backgroundColor: "#e3eaef",
                            borderColor: "#e3eaef",
                            hoverBackgroundColor: "#e3eaef",
                            hoverBorderColor: "#e3eaef",
                            data: [89, 40, 32, 65, 59, 80, 81, 56, 89, 40, 65, 59]
                        }
                    ]
                },
                {
                    maintainAspectRatio: !1,
                    legend: { display: !1 },
                    tooltips: {
                        backgroundColor: "#dee2e6",
                        titleFontColor: "#5089de",
                        bodyFontColor: "#000",
                        bodyFontSize: 14,
                        displayColors: !1
                    },
                    scales: {
                        yAxes: [{ gridLines: { display: !1 }, stacked: !1, ticks: { stepSize: 20 } }],
                        xAxes: [
                            {
                                barPercentage: .7,
                                categoryPercentage: .5,
                                stacked: !1,
                                gridLines: { color: "rgba(0,0,0,0.01)" }
                            }
                        ]
                    }
                }))
        }
        if (0 < d("#pie-chart-example").length) {
            a.push(this.respChart(d("#pie-chart-example"),
                "Pie",
                {
                    labels: ["Direct", "Affilliate", "Sponsored", "E-mail"],
                    datasets: [
                        {
                            data: [300, 135, 48, 154],
                            backgroundColor: ["#3bafda", "#f7b84b", "#1abc9c", "#ebeff2"],
                            borderColor: "transparent"
                        }
                    ]
                },
                {
                    maintainAspectRatio: !1,
                    tooltips: {
                        backgroundColor: "#dee2e6",
                        titleFontColor: "#5089de",
                        bodyFontColor: "#000",
                        bodyFontSize: 14,
                        displayColors: !1
                    },
                    legend: { display: !1 }
                }))
        }
        if (0 < d("#donut-chart-example").length) {
            a.push(this.respChart(d("#donut-chart-example"),
                "Doughnut",
                {
                    labels: ["Direct", "Affilliate", "Sponsored"],
                    datasets: [
                        {
                            data: [128, 78, 48],
                            backgroundColor: ["#3bafda", "#1abc9c", "#ebeff2"],
                            borderColor: "transparent",
                            borderWidth: "3"
                        }
                    ]
                },
                {
                    maintainAspectRatio: !1,
                    cutoutPercentage: 60,
                    tooltips: {
                        backgroundColor: "#dee2e6",
                        titleFontColor: "#5089de",
                        bodyFontColor: "#000",
                        bodyFontSize: 14,
                        displayColors: !1
                    },
                    legend: { display: !1 }
                }))
        }
        if (0 < d("#polar-chart-example").length) {
            a.push(this.respChart(d("#polar-chart-example"),
                "PolarArea",
                {
                    labels: ["Direct", "Affilliate", "Sponsored", "E-mail"],
                    datasets: [
                        {
                            data: [251, 135, 48, 154],
                            backgroundColor: ["#3bafda", "#f7b84b", "#1abc9c", "#ebeff2"],
                            borderColor: "transparent"
                        }
                    ]
                },
                {
                    scale: { ticks: { backdropColor: "#253138" } },
                    tooltips: {
                        backgroundColor: "#dee2e6",
                        titleFontColor: "#5089de",
                        bodyFontColor: "#000",
                        bodyFontSize: 14,
                        displayColors: !1
                    }
                }))
        }
        if (0 < d("#radar-chart-example").length) {
            a.push(this.respChart(d("#radar-chart-example"),
                "Radar",
                {
                    labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
                    datasets: [
                        {
                            label: "Desktops",
                            backgroundColor: "rgba(59, 175, 218,0.2)",
                            borderColor: "#3bafda",
                            pointBackgroundColor: "#3bafda",
                            pointBorderColor: "#fff",
                            pointHoverBackgroundColor: "#fff",
                            pointHoverBorderColor: "#3bafda",
                            data: [65, 59, 90, 81, 56, 55, 40]
                        },
                        {
                            label: "Tablets",
                            backgroundColor: "rgba(246, 114, 167,0.2)",
                            borderColor: "#f672a7",
                            pointBackgroundColor: "#f672a7",
                            pointBorderColor: "#fff",
                            pointHoverBackgroundColor: "#fff",
                            pointHoverBorderColor: "#f672a7",
                            data: [28, 48, 40, 19, 96, 27, 100]
                        }
                    ]
                },
                {
                    maintainAspectRatio: !1,
                    tooltips: {
                        backgroundColor: "#dee2e6",
                        titleFontColor: "#5089de",
                        bodyFontColor: "#000",
                        bodyFontSize: 14,
                        displayColors: !1
                    },
                    scale: { ticks: { backdropColor: "#253138" } }
                }))
        }
        return a
    }, a.prototype.init = function() {
        var e = this;
        Chart.defaults.global.defaultFontFamily =
                '-apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,Oxygen-Sans,Ubuntu,Cantarell,"Helvetica Neue",sans-serif',
            e.charts = this.initCharts(), d(window).on("resize",
                function(a) {
                    d.each(e.charts,
                        function(a, e) {
                            try {
                                e.destroy()
                            } catch (a) {
                            }
                        }), e.charts = e.initCharts()
                })
    }, d.ChartJs = new a, d.ChartJs.Constructor = a
}(window.jQuery), function(a) {
    "use strict";
    window.jQuery.ChartJs.init()
}();
for (var dateFormat = "MMMM DD YYYY",
    date = moment("April 01 2017", dateFormat),
    data = [randomBar(date, 30)],
    labels = [date];
    data.length < 24;
)
    (date = date.clone().add(1, "d")).isoWeekday() <= 5 &&
        (data.push(randomBar(date, data[data.length - 1].y)), labels.push(date));
var ctx = document.getElementById("financial-report").getContext("2d");
ctx.canvas.width = 1e3;
var cfg = {
        type: "bar",
        data: {
            labels: labels,
            datasets: [
                {
                    label: "CHRT - Chart.js Corporation",
                    data: data,
                    type: "line",
                    pointRadius: 0,
                    fill: !(ctx.canvas.height = 300),
                    fill: !1,
                    borderColor: "#3bafda",
                    backgroundColor: "rgba(59, 175, 218,0.2)",
                    lineTension: 0,
                    borderWidth: 2
                }
            ]
        },
        options: {
            scales: {
                xAxes: [{ type: "time", distribution: "series", ticks: { source: "labels" } }],
                yAxes: [{ scaleLabel: { display: !0, labelString: "Closing price ($)" } }]
            }
        }
    },
    chart = new Chart(ctx, cfg);
document.getElementById("update").addEventListener("click",
    function() {
        var a = document.getElementById("type").value;
        chart.config.data.datasets[0].type = a, chart.update()
    });