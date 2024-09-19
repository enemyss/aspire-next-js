export default async function Home() {
  const data = await fetch(
    `${process.env.services__api__https__0}/weatherforecast`
  );
  const weather = await data.json();

  return (
    <div className="grid grid-rows-[20px_1fr_20px] items-center justify-items-center min-h-screen p-8 pb-20 gap-16 sm:p-20 font-[family-name:var(--font-geist-sans)]">
      <main className="flex flex-col gap-8 row-start-2 items-center sm:items-start">
        <div>
          <p>API data:</p>
          {weather.map((item) => (
            <li key={item.date}>{item.summary}</li>
          ))}
        </div>
      </main>
    </div>
  );
}
