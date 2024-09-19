import { registerOTel } from '@vercel/otel'
 
export function register() {
  console.log(process.env.OTEL_SERVICE_NAME);
  registerOTel({ serviceName: process.env.OTEL_SERVICE_NAME })
}