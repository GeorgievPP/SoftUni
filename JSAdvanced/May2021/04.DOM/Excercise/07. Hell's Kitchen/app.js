function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   const inputData = document.querySelector('#inputs textarea');
   const bestRestaurant = document.querySelector('#bestRestaurant p');
   const bestWorkers = document.querySelector('#workers p');

   function onClick () {
      let restaurants = {};

      JSON.parse(inputData.value).forEach((el) => {
         const [restaurantName, data] = el.split(' - ');
         const workers = data.split(', ');

         let arraysWorkers = [];

         for(const worker of workers) {
            const [name, salary] = worker.split(' ');
            arraysWorkers.push({
               name,
               salary,
            });
         };

         if(restaurants[restaurantName]) {
            arraysWorkers = arraysWorkers.concat(restaurants[restaurantName].arraysWorkers);
         };

         arraysWorkers.sort((a, b) => b.salary - a.salary);
         const bestSalary = Number(arraysWorkers[0].salary);
         const averageSalary = arraysWorkers
            .reduce((sum, worker) => sum + Number(worker.salary), 0) / arraysWorkers.length;

         restaurants[restaurantName] = {
            arraysWorkers,
            averageSalary,
            bestSalary,
         };
      });

      let bestResaturant = undefined;
      let bestAverageSalary = 0;
      let bestName = undefined;

      for (const restaurant in restaurants) {
          const currAverageSalary = restaurants[restaurant].averageSalary;
          if (currAverageSalary > bestAverageSalary) {

              bestAverageSalary = currAverageSalary;
              bestResaturant = restaurants[restaurant];
              bestName = restaurant;
          }
      };

      const x = bestResaturant;
      bestRestaurant.textContent = `Name: ${bestName} 
          Average Salary: ${bestResaturant.averageSalary.toFixed(2)}
          Best Salary: ${bestResaturant.bestSalary.toFixed(2)}`;

      let arrayOfBestWorkers = [];
      bestResaturant.arrayWorkers.forEach((worker) => {
          arrayOfBestWorkers.push(`Name: ${worker.name} With Salary: ${worker.salary}`);
      });

      bestWorkers.textContent = arrayOfBestWorkers.join(" ");
      
   }
}