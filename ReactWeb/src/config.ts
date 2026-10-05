const config ={
    baseApiUrl:"https://localhost:4000"
} 

const currencyFormatter = Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 0
});
export default config;
export { currencyFormatter };