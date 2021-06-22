function solve() {
   const output = document.querySelector('textarea');

   const cart = [];

   document.querySelector('.shopping-cart').addEventListener('click', (ev) => {
      if(ev.target.tagName === 'BUTTON' && ev.target.className === 'add-product') {
         const product = ev.target.parentNode.parentNode;
         const title = product.querySelector('.product-title').textContent;
         const price = Number(product.querySelector('.product-line-price').textContent);

         cart.push({title, price});

         output.value += `Added ${title} for ${price.toFixed(2)} to the cart.\n`;
      }
   });

   document.querySelector('.checkout').addEventListener('click', () => {
      const result = cart.reduce((acc, c) => {
         acc.items.add(c.title);
         acc.total += c.price;
         return acc;
      }, {items: [], total: 0});

      [...document.getElementsByTagName('button')].forEach((el) => 
         el.setAttribute('disabled', ''));

      output.value += `You bought ${Array.from(new Set(result.items)).join(', ')} for ${result.total.toFixed(2)}.`;
   });
}  // 25/100