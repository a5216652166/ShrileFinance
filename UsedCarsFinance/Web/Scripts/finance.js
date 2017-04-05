// 月供计算
function PMT(rate, nper, pv, fv, type) {
    /*
    rate - interest rate per month
    nper - number of periods (months)
    pv - present value
    fv - future value (residual value)
    type - payments occur at the start(0) / end(1) of the period
    */
    fv = fv || 0;
    type = type || 0;

    pmt = (rate * (pv * Math.pow((rate + 1), nper) + fv)) / ((rate * type + 1) * (Math.pow((rate + 1), nper) - 1));
    return pmt;
}

// 月利率转年利率
function RateMTY(rateofmonth) {
    return rateofmonth * 12;
}

// 年利率转月利率
function RateYTM(rateofyear) {
    return rateofyear / 12;
}