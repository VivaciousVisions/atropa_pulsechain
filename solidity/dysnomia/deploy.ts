const fs = require('fs')
import { ethers } from 'ethers'

// execute remix.exeCurrent() from the > command prompt at the bottom of the remixz

const deploy = async (contractName: string, args: Array<any>, accountIndex?: number): Promise<ethers.Contract> => {
  console.log(`deploying ${contractName}`)
  const libartifactsPath = `browser/solidity/dysnomia/lib/artifacts/${contractName}.json`
  const artifactsPath = `browser/solidity/dysnomia/artifacts/${contractName}.json`
  try { await remix.call('fileManager', 'rename', libartifactsPath, artifactsPath) } catch {}
  const metadata = JSON.parse(await remix.call('fileManager', 'getFile', artifactsPath))
  const signer = (new ethers.providers.Web3Provider(web3Provider)).getSigner(accountIndex)
  const factory = new ethers.ContractFactory(metadata.abi, metadata.data.bytecode.object, signer)
  const contract = await factory.deploy(...args)
  await contract.deployed()
  return contract
}

let result
let vmreqaddress
let shafactoryaddress
let shiofactoryaddress
let yiaddress
let zhengaddress
let zhouaddress
let yauaddress
let yangaddress
let siuaddress 
let voidaddress
let libattributeaddress
let START = 0;
// set pre-requisite address to deploy only subset ie: = ethers.utils.getAddress("0xD2F5793e91D3043002f478aa06A023D4FAE12777")

(async () => {
  try {
    switch (START) {
      case 0:
        result = await deploy('VMREQ', [])
        console.log(`VMREQ address: ${result.address}`)
        vmreqaddress = result.address

      case 1:
        result = await deploy('SHAFactory', [])
        console.log(`SHAFactory address: ${result.address}`)
        shafactoryaddress = result.address

      case 2:
        result = await deploy('SHIOFactory', [])
        console.log(`SHIOFactory address: ${result.address}`)
        shiofactoryaddress = result.address

      case 3:
        result = await deploy('YI', [shafactoryaddress, shiofactoryaddress, vmreqaddress])
        console.log(`YI address: ${result.address}`)
        yiaddress = result.address

      case 4:
        result = await deploy('ZHENG', [yiaddress])
        console.log(`ZHENG address: ${result.address}`)
        zhengaddress = result.address

      case 5:
        result = await deploy('ZHOU', [zhengaddress])
        console.log(`ZHOU address: ${result.address}`)
        zhouaddress = result.address

      case 6:
        result = await deploy('YAU', [zhouaddress])
        console.log(`YAU address: ${result.address}`)
        yauaddress = result.address

      case 7:
        result = await deploy('YANG', [yauaddress])
        console.log(`YANG address: ${result.address}`)
        yangaddress = result.address

      case 8:
        result = await deploy('SIU', [yangaddress])
        console.log(`SIU address: ${result.address}`)
        siuaddress = result.address

      case 9:
        result = await deploy('VOID', [siuaddress])
        console.log(`VOID address: ${result.address}`)
        voidaddress = result.address

      case 10:
        result = await deploy('ATTRIBUTE', [voidaddress]) 
        console.log(`ATTRIBUTE address: ${result.address}`)
        libattributeaddress = result.address
    }
  } catch (e) {
    console.log(e.message)
  }
})()

/*
async function deploy(contractName, contractArgs) {
  try {
    const artifactsPath = `browser/solidity/dysnomia/artifacts/${contractName}.json`
    const metadata = JSON.parse(await remix.call('fileManager', 'getFile', artifactsPath))
    const signer = (new ethers.providers.Web3Provider(web3Provider)).getSigner()
    let factory = new ethers.ContractFactory(metadata.abi, metadata.data.bytecode.object, signer);
    let contract = await factory.deploy(contractArgs);
    console.log(contract.address);
    console.log(contract.deployTransaction.hash);
    await contract.deployed()
    console.log('contract deployed')
    return contract.address;
  } catch (e) {
    console.log(e.message)
  }
};

vmreqaddress = deploy("VMREQ", null);
shafactoryaddress = deploy("SHAFactory", null);
shiofactoryaddress = deploy("SHIOFactory", null);
deploy("YI", [shafactoryaddress, shiofactoryaddress, vmreqaddress]);
*/